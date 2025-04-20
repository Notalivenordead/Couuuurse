using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Apllication4Course.Models;

namespace Apllication4Course.ViewModels
{
    public class EmployeeViewModel : SearchSortViewModel<Сотрудники>
    {
        public ObservableCollection<Сотрудники> Employees => Items;
        public EmployeeViewModel()
        {
            AddCommand = new RelayCommand(AddNewItem);
            EditCommand = new RelayCommand(EditSelectedItem, () => IsEditEnabled);
            DeleteCommand = new RelayCommand(DeleteSelectedItem, () => IsDeleteEnabled);
            SaveCommand = new RelayCommand(SaveChanges);
        }

        protected override Dictionary<string, Expression<Func<Сотрудники, object>>> CreateSortProperties()
        {
            return new Dictionary<string, Expression<Func<Сотрудники, object>>>
            {
                ["Логин"] = x => x.Логин,
                ["ФИО"] = x => x.ФИО,
                ["Должность"] = x => x.Должность
            };
        }

        protected override bool FilterPredicate(Сотрудники item)
        {
            if (string.IsNullOrWhiteSpace(SearchText))
                return true;

            // Ищем по основным полям (регистронезависимо)
            return (item.Логин != null && item.Логин.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                   (item.ФИО != null && item.ФИО.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                   (item.Должность != null && item.Должность.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}
