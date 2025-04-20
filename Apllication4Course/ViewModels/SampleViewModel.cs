using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Apllication4Course.Models;
using System.Globalization;

namespace Apllication4Course.ViewModels
{
    public class SampleViewModel : SearchSortViewModel<Образцы>
    {
       public ObservableCollection<Образцы> Samples => Items;

        public SampleViewModel()
        {
            AddCommand = new RelayCommand(AddNewItem);
            EditCommand = new RelayCommand(EditSelectedItem, () => IsEditEnabled);
            DeleteCommand = new RelayCommand(DeleteSelectedItem, () => IsDeleteEnabled);
            SaveCommand = new RelayCommand(SaveChanges);
        }

        protected override Dictionary<string, Expression<Func<Образцы, object>>> CreateSortProperties()
        {
            return new Dictionary<string, Expression<Func<Образцы, object>>>
            {
                ["Тип Образца"] = x => x.Тип_Образца,
                ["Дата взятия"] = x => x.Дата_Взятия,
                ["Условия Хранения"] = x => x.Условия_Хранения
            };
        }

        protected override bool FilterPredicate(Образцы item)
        {
            if (string.IsNullOrWhiteSpace(SearchText))
                return true;


            // Поиск по дате (поддержка разных форматов)
            if (item.Дата_Взятия != null)
            {
                // Проверяем все компоненты даты/времени отдельно
                if (item.Дата_Взятия.Day.ToString().Contains(SearchText) ||
                    item.Дата_Взятия.Month.ToString().Contains(SearchText) ||
                    item.Дата_Взятия.Year.ToString().Contains(SearchText) ||
                    item.Дата_Взятия.Hour.ToString().Contains(SearchText) ||
                    item.Дата_Взятия.Minute.ToString().Contains(SearchText) ||
                    item.Дата_Взятия.Second.ToString().Contains(SearchText))
                {
                    return true;
                }

                if (item.Дата_Взятия.ToString("dd.MM.yyyy HH:mm:ss").Contains(SearchText) ||
                    item.Дата_Взятия.ToString("yyyy-MM-dd HH:mm:ss").Contains(SearchText))
                {
                    return true;
                }
            }

            // Ищем по основным полям (регистронезависимо)
            return (item.Тип_Образца != null && item.Тип_Образца.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                   (item.Условия_Хранения != null && item.Условия_Хранения.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}
