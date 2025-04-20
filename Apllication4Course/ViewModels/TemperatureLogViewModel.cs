using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Apllication4Course.Models;
using System.Globalization;

namespace Apllication4Course.ViewModels
{
    public class TemperatureLogViewModel : SearchSortViewModel<Журнал_Температур>
    {
        public ObservableCollection<Журнал_Температур> TemperatureLogs => Items;

        public TemperatureLogViewModel()
        {
            AddCommand = new RelayCommand(AddNewItem);
            EditCommand = new RelayCommand(EditSelectedItem, () => IsEditEnabled);
            DeleteCommand = new RelayCommand(DeleteSelectedItem, () => IsDeleteEnabled);
            SaveCommand = new RelayCommand(SaveChanges);
        }

        protected override Dictionary<string, Expression<Func<Журнал_Температур, object>>> CreateSortProperties()
        {
            return new Dictionary<string, Expression<Func<Журнал_Температур, object>>>
            {
                ["ФИО"] = x => x.Температура,
                ["Дата поступления"] = x => x.Дата_Измерения
            };
        }

        protected override bool FilterPredicate(Журнал_Температур item)
        {
            if (string.IsNullOrWhiteSpace(SearchText))
                return true;

            // Поиск по дате (поддержка разных форматов)
            if (item.Дата_Измерения != null)
            {
                // Проверяем все компоненты даты/времени отдельно
                if (item.Дата_Измерения.Day.ToString().Contains(SearchText) ||       
                    item.Дата_Измерения.Month.ToString().Contains(SearchText) ||     
                    item.Дата_Измерения.Year.ToString().Contains(SearchText) ||     
                    item.Дата_Измерения.Hour.ToString().Contains(SearchText) ||      
                    item.Дата_Измерения.Minute.ToString().Contains(SearchText) ||    
                    item.Дата_Измерения.Second.ToString().Contains(SearchText))      
                {
                    return true;
                }

                if (item.Дата_Измерения.ToString("dd.MM.yyyy HH:mm:ss").Contains(SearchText) ||
                    item.Дата_Измерения.ToString("yyyy-MM-dd HH:mm:ss").Contains(SearchText))
                {
                    return true;
                }
            }

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
            return false;
        }
    }
}
