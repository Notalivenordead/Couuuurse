using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Apllication4Course.Models;
using System.Globalization;

namespace Apllication4Course.ViewModels
{
    public class PaidResearchViewModel : SearchSortViewModel<Платные_Исследования>
    {
        public ObservableCollection<Платные_Исследования> PaidResearches => Items;

        public PaidResearchViewModel() 
        {
            AddCommand = new RelayCommand(AddNewItem);
            EditCommand = new RelayCommand(EditSelectedItem, () => IsEditEnabled);
            DeleteCommand = new RelayCommand(DeleteSelectedItem, () => IsDeleteEnabled);
            SaveCommand = new RelayCommand(SaveChanges);
        }

        protected override Dictionary<string, Expression<Func<Платные_Исследования, object>>> CreateSortProperties()
        {
            return new Dictionary<string, Expression<Func<Платные_Исследования, object>>>
            {
                ["Тип Исследования"] = x => x.Тип_Исследования,
                ["Дата Проведения"] = x => x.Дата_Проведения,
                ["Результаты"] = x => x.Результаты
            };
        }

        protected override bool FilterPredicate(Платные_Исследования item)
        {
            if (string.IsNullOrWhiteSpace(SearchText))
                return true;


            // Поиск по дате (поддержка разных форматов)
            if (item.Дата_Проведения != null)
            {
                // Проверяем все компоненты даты/времени отдельно
                if (item.Дата_Проведения.Day.ToString().Contains(SearchText) ||
                    item.Дата_Проведения.Month.ToString().Contains(SearchText) ||
                    item.Дата_Проведения.Year.ToString().Contains(SearchText) ||
                    item.Дата_Проведения.Hour.ToString().Contains(SearchText) ||
                    item.Дата_Проведения.Minute.ToString().Contains(SearchText) ||
                    item.Дата_Проведения.Second.ToString().Contains(SearchText))
                {
                    return true;
                }

                if (item.Дата_Проведения.ToString("dd.MM.yyyy HH:mm:ss").Contains(SearchText) ||
                    item.Дата_Проведения.ToString("yyyy-MM-dd HH:mm:ss").Contains(SearchText))
                {
                    return true;
                }
            }

            // Ищем по основным полям (регистронезависимо)
            return (item.Тип_Исследования != null && item.Тип_Исследования.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                   (item.Результаты != null && item.Результаты.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0);
        }

    }
}
