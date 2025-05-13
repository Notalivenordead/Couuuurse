using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq.Expressions;
using Apllication4Course.Models;

namespace Apllication4Course.ViewModels
{
    public class StorageViewModel : SearchSortViewModel<Камеры_Хранения>
    {
        public ObservableCollection<Камеры_Хранения> Storage => Items;

        public StorageViewModel()
        {
            AddCommand = new RelayCommand(AddNewItem);
            EditCommand = new RelayCommand(EditSelectedItem, () => IsEditEnabled);
            DeleteCommand = new RelayCommand(DeleteSelectedItem, () => IsDeleteEnabled);
            SaveCommand = new RelayCommand(SaveChanges);
        }

        protected override Dictionary<string, Expression<Func<Камеры_Хранения, object>>> CreateSortProperties()
        {
            return new Dictionary<string, Expression<Func<Камеры_Хранения, object>>>
            {
                ["Температура"] = x => x.Температура,
                ["Номер_Камеры"] = x => x.Номер_Камеры
            };
        }

        protected override bool FilterPredicate(Камеры_Хранения item)
        {
            if (string.IsNullOrWhiteSpace(SearchText))
                return true;

            // Поиск по температуре
            if (item != null)
            {
                // Точное совпадение числа
                if (decimal.TryParse(SearchText, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal searchTemp))
                {
                    if (item.Температура == searchTemp)
                        return true;
                }

                // Поиск в строковом представлении
                if (item.Температура.ToString(CultureInfo.InvariantCulture).Contains(SearchText))
                    return true;
            }

            // Поиск по номеру камеры
            if (item != null)
            {
                // Точное совпадение числа
                if (decimal.TryParse(SearchText, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal searchTemp))
                {
                    if (item.Номер_Камеры == searchTemp)
                        return true;
                }

                // Поиск в строковом представлении
                if (item.Номер_Камеры.ToString(CultureInfo.InvariantCulture).Contains(SearchText))
                    return true;
            }
            return false;
        }
    }
}
