using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Apllication4Course.Models;

namespace Apllication4Course.ViewModels
{
    public class DeceasedViewModel : SearchSortViewModel<Умершие>
    {
        public ObservableCollection<Умершие> Deceased => Items;
        public DeceasedViewModel()
        {
            AddCommand = new RelayCommand(AddNewItem);
            EditCommand = new RelayCommand(EditSelectedItem, () => IsEditEnabled);
            DeleteCommand = new RelayCommand(DeleteSelectedItem, () => IsDeleteEnabled);
            SaveCommand = new RelayCommand(SaveChanges);
        }

        protected override Dictionary<string, Expression<Func<Умершие, object>>> CreateSortProperties()
        {
            return new Dictionary<string, Expression<Func<Умершие, object>>>
            {
                ["ФИО"] = x => x.ФИО,
                ["Дата поступления"] = x => x.Дата_Поступления,
                ["Дата смерти"] = x => x.Дата_Смерти,
                ["Причина смерти"] = x => x.Причина_Смерти
            };
        }

        protected override bool FilterPredicate(Умершие item)
        {
            if (string.IsNullOrWhiteSpace(SearchText))
                return true;


            // Поиск по дате (поддержка разных форматов)
            if (item.Дата_Поступления != null)
            {
                // Проверяем все компоненты даты/времени отдельно
                if (item.Дата_Поступления.Day.ToString().Contains(SearchText) ||
                    item.Дата_Поступления.Month.ToString().Contains(SearchText) ||
                    item.Дата_Поступления.Year.ToString().Contains(SearchText) ||
                    item.Дата_Поступления.Hour.ToString().Contains(SearchText) ||
                    item.Дата_Поступления.Minute.ToString().Contains(SearchText) ||
                    item.Дата_Поступления.Second.ToString().Contains(SearchText))
                {
                    return true;
                }

                if (item.Дата_Поступления.ToString("dd.MM.yyyy HH:mm:ss").Contains(SearchText) ||
                    item.Дата_Поступления.ToString("yyyy-MM-dd HH:mm:ss").Contains(SearchText))
                {
                    return true;
                }
            }

            // Поиск по дате (поддержка разных форматов)
            if (item.Дата_Смерти != null)
            {
                // Проверяем все компоненты даты/времени отдельно
                if (item.Дата_Смерти.Day.ToString().Contains(SearchText) ||
                    item.Дата_Смерти.Month.ToString().Contains(SearchText) ||
                    item.Дата_Смерти.Year.ToString().Contains(SearchText) ||
                    item.Дата_Смерти.Hour.ToString().Contains(SearchText) ||
                    item.Дата_Смерти.Minute.ToString().Contains(SearchText) ||
                    item.Дата_Смерти.Second.ToString().Contains(SearchText))
                {
                    return true;
                }

                if (item.Дата_Смерти.ToString("dd.MM.yyyy HH:mm:ss").Contains(SearchText) ||
                    item.Дата_Смерти.ToString("yyyy-MM-dd HH:mm:ss").Contains(SearchText))
                {
                    return true;
                }
            }

            // Ищем по основным полям (регистронезависимо)
            return (item.ФИО != null && item.ФИО.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                   (item.Причина_Смерти != null && item.Причина_Смерти.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0); 
        }
    }
}
