using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Apllication4Course.Models;
using System.Globalization;

namespace Apllication4Course.ViewModels
{
    public class FinancialOperationViewModel : SearchSortViewModel<Финансовые_Операции>
    {
        public ObservableCollection<Финансовые_Операции> FinancialOperations => Items;
        public FinancialOperationViewModel()
        {
            AddCommand = new RelayCommand(AddNewItem);
            EditCommand = new RelayCommand(EditSelectedItem, () => IsEditEnabled);
            DeleteCommand = new RelayCommand(DeleteSelectedItem, () => IsDeleteEnabled);
            SaveCommand = new RelayCommand(SaveChanges);
        }

        protected override Dictionary<string, Expression<Func<Финансовые_Операции, object>>> CreateSortProperties()
        {
            return new Dictionary<string, Expression<Func<Финансовые_Операции, object>>>
            {
                ["Сумма операции"] = x => x.Сумма,
                ["Дата операции"] = x => x.Дата_Операции,
                ["Тип операции"] = x => x.Тип,
                ["Способ оплаты"] = x => x.СпособОплаты
            };
        }

        protected override bool FilterPredicate(Финансовые_Операции item)
        {
            if (string.IsNullOrWhiteSpace(SearchText))
                return true;


            // Поиск по дате (поддержка разных форматов)
            if (item.Дата_Операции != null)
            {
                // Проверяем все компоненты даты/времени отдельно
                if (item.Дата_Операции.Day.ToString().Contains(SearchText) ||
                    item.Дата_Операции.Month.ToString().Contains(SearchText) ||
                    item.Дата_Операции.Year.ToString().Contains(SearchText) ||
                    item.Дата_Операции.Hour.ToString().Contains(SearchText) ||
                    item.Дата_Операции.Minute.ToString().Contains(SearchText) ||
                    item.Дата_Операции.Second.ToString().Contains(SearchText))
                {
                    return true;
                }

                if (item.Дата_Операции.ToString("dd.MM.yyyy HH:mm:ss").Contains(SearchText) ||
                    item.Дата_Операции.ToString("yyyy-MM-dd HH:mm:ss").Contains(SearchText))
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
                    if (item.Сумма == searchTemp)
                        return true;
                }

                // Поиск в строковом представлении
                if (item.Сумма.ToString(CultureInfo.InvariantCulture).Contains(SearchText))
                    return true;
            }

            // Ищем по основным полям (регистронезависимо)
            return item.Тип != null && item.Тип.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
