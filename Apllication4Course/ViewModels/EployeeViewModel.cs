using System.Collections.ObjectModel;
using Apllication4Course.Models;

namespace Apllication4Course.ViewModels
{
    public class EmployeeViewModel : BaseDataViewModel<Сотрудники>
    {
        public ObservableCollection<Сотрудники> Employees => Items as ObservableCollection<Сотрудники>;
    }
}