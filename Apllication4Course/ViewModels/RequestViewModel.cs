using Apllication4Course.Models;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;


namespace Apllication4Course.ViewModels
{
    public class RequestViewModel : SearchSortViewModel<Заявки_на_Платные_Услуги>
    {
        public ObservableCollection<Заявки_на_Платные_Услуги> Requests => Items;
        public RequestViewModel()
        {
            AddCommand = new RelayCommand(AddNewItem);
            EditCommand = new RelayCommand(EditSelectedItem, () => IsEditEnabled);
            DeleteCommand = new RelayCommand(DeleteSelectedItem, () => IsDeleteEnabled);
            SaveCommand = new RelayCommand(SaveChanges);
        }

        protected override Dictionary<string, Expression<Func<Заявки_на_Платные_Услуги, object>>> CreateSortProperties()
        {
            return new Dictionary<string, Expression<Func<Заявки_на_Платные_Услуги, object>>>
            {
                ["ФИО"] = x => x.ФИО_Заказчика,
                ["Дата подачи"] = x => x.Дата_Подачи,
                ["Статус"] = x => x.Статус
            };
        }

        protected override bool FilterPredicate(Заявки_на_Платные_Услуги item)
        {
            if (string.IsNullOrWhiteSpace(SearchText))
                return true;


            // Поиск по дате (поддержка разных форматов)
            if (item.Дата_Подачи  != null)
            {
                // Проверяем все компоненты даты/времени отдельно
                if (item.Дата_Подачи.Day.ToString().Contains(SearchText) ||
                    item.Дата_Подачи.Month.ToString().Contains(SearchText) ||
                    item.Дата_Подачи.Year.ToString().Contains(SearchText) ||
                    item.Дата_Подачи.Hour.ToString().Contains(SearchText) ||
                    item.Дата_Подачи.Minute.ToString().Contains(SearchText) ||
                    item.Дата_Подачи.Second.ToString().Contains(SearchText))
                {
                    return true;
                }

                if (item.Дата_Подачи.ToString("dd.MM.yyyy HH:mm:ss").Contains(SearchText) ||
                    item.Дата_Подачи.ToString("yyyy-MM-dd HH:mm:ss").Contains(SearchText))
                {
                    return true;
                }
            }

            // Ищем по основным полям (регистронезависимо)
            return (item.ФИО_Заказчика != null && item.ФИО_Заказчика.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                   (item.Статус != null && item.Статус.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                   (item.КонтактныйТелефон != null && item.КонтактныйТелефон.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}
