using Apllication4Course.Models;
using Apllication4Course.ViewModels;
using System.Collections.ObjectModel;


namespace Apllication4Course.ViewModels
{
    public class RequestViewModel : BaseDataViewModel<Заявки_на_Платные_Услуги>
    {
        public ObservableCollection<Заявки_на_Платные_Услуги> Requests => Items;
        public RequestViewModel()
        {
            AddCommand = new RelayCommand(AddNewItem);
            EditCommand = new RelayCommand(EditSelectedItem, () => IsEditEnabled);
            DeleteCommand = new RelayCommand(DeleteSelectedItem, () => IsDeleteEnabled);
            SaveCommand = new RelayCommand(SaveChanges);
        }
    }
}
