using Apllication4Course.Models;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Globalization;

namespace Apllication4Course.ViewModels
{
    public class ServiceViewModel : SearchSortViewModel<Услуги>
    {
        public ObservableCollection<Услуги> Services => Items;

        public ServiceViewModel()
        {
            AddCommand = new RelayCommand(AddNewItem);
            EditCommand = new RelayCommand(EditSelectedItem, () => IsEditEnabled);
            DeleteCommand = new RelayCommand(DeleteSelectedItem, () => IsDeleteEnabled);
            SaveCommand = new RelayCommand(SaveChanges);
        }

        protected override Dictionary<string, Expression<Func<Услуги, object>>> CreateSortProperties()
        {
            return new Dictionary<string, Expression<Func<Услуги, object>>>
            {
                ["Наименование"] = x => x.Наименование,
                ["Стоимость"] = x => x.Стоимость,
                ["Тип услуги"] = x => x.Тип
            };
        }

        protected override bool FilterPredicate(Услуги item)
        {
            if (string.IsNullOrWhiteSpace(SearchText))
                return true;

            // Поиск по стоимости
            if (item != null)
            {
                // Точное совпадение числа
                if (decimal.TryParse(SearchText, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal searchTemp))
                {
                    if (item.Стоимость == searchTemp)
                        return true;
                }

                // Поиск в строковом представлении
                if (item.Стоимость.ToString(CultureInfo.InvariantCulture).Contains(SearchText))
                    
                    return true;
            }
            // Ищем по основным полям (регистронезависимо)
            return (item.Наименование != null && item.Наименование.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                   (item.Тип != null && item.Тип.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }   
}
