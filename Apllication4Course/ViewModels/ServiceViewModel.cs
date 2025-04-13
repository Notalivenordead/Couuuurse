using Apllication4Course.Models;
using System.Collections.ObjectModel;

namespace Apllication4Course.ViewModels
{
    public class ServiceViewModel : BaseDataViewModel<Услуги>
    {
        public ObservableCollection<Услуги> Services => Items;

        public ServiceViewModel()
        {
            AddCommand = new RelayCommand(AddNewItem);
            EditCommand = new RelayCommand(EditSelectedItem, () => IsEditEnabled);
            DeleteCommand = new RelayCommand(DeleteSelectedItem, () => IsDeleteEnabled);
            SaveCommand = new RelayCommand(SaveChanges);
        }
    }   
}
