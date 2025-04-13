using System.Collections.ObjectModel;
using Apllication4Course.Models;

namespace Apllication4Course.ViewModels
{
    public class EmployeeViewModel : BaseDataViewModel<Сотрудники>
    {
        public ObservableCollection<Сотрудники> Employees => Items;
        public EmployeeViewModel()
        {
            AddCommand = new RelayCommand(AddNewItem);
            EditCommand = new RelayCommand(EditSelectedItem, () => IsEditEnabled);
            DeleteCommand = new RelayCommand(DeleteSelectedItem, () => IsDeleteEnabled);
            SaveCommand = new RelayCommand(SaveChanges);
        }
    }
}
