using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Apllication4Course.Models;
using System.Globalization;

namespace Apllication4Course.ViewModels
{
    public class TransportationViewModel : SearchSortViewModel<Транспортировка>
    {
        public ObservableCollection<Транспортировка> Transportations => Items;

        public TransportationViewModel()
        {
            AddCommand = new RelayCommand(AddNewItem);
            EditCommand = new RelayCommand(EditSelectedItem, () => IsEditEnabled);
            DeleteCommand = new RelayCommand(DeleteSelectedItem, () => IsDeleteEnabled);
            SaveCommand = new RelayCommand(SaveChanges);
        }

        protected override Dictionary<string, Expression<Func<Транспортировка, object>>> CreateSortProperties()
        {
            return new Dictionary<string, Expression<Func<Транспортировка, object>>>
            {
                ["Тип перемещения"] = x => x.Тип_Перемещения,
                ["Дата перемещения"] = x => x.Дата_Время,
                ["Место отправления"] = x => x.Место_Отправления,
                ["Место назанчения"] = x => x.Место_Назначения
            };
        }

        protected override bool FilterPredicate(Транспортировка item)
        {
            if (string.IsNullOrWhiteSpace(SearchText))
                return true;


            // Поиск по дате (поддержка разных форматов)
            if (item.Дата_Время != null)
            {
                // Проверяем все компоненты даты/времени отдельно
                if (item.Дата_Время.Day.ToString().Contains(SearchText) ||
                    item.Дата_Время.Month.ToString().Contains(SearchText) ||
                    item.Дата_Время.Year.ToString().Contains(SearchText) ||
                    item.Дата_Время.Hour.ToString().Contains(SearchText) ||
                    item.Дата_Время.Minute.ToString().Contains(SearchText) ||
                    item.Дата_Время.Second.ToString().Contains(SearchText))
                {
                    return true;
                }

                if (item.Дата_Время.ToString("dd.MM.yyyy HH:mm:ss").Contains(SearchText) ||
                    item.Дата_Время.ToString("yyyy-MM-dd HH:mm:ss").Contains(SearchText))
                {
                    return true;
                }
            }

            // Ищем по основным полям (регистронезависимо)
            return (item.Тип_Перемещения != null && item.Тип_Перемещения.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                   (item.Место_Отправления != null && item.Место_Отправления.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                   (item.Место_Назначения != null && item.Место_Назначения.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}
