using System.Collections.ObjectModel;
using Apllication4Course.Models;

namespace Apllication4Course.ViewModels
{
    public class TransportationViewModel : BaseDataViewModel<Транспортировка>
    {
        public ObservableCollection<Транспортировка> Transportations => Items;

        public TransportationViewModel()
        {
            AddCommand = new RelayCommand(AddNewItem);
            EditCommand = new RelayCommand(EditSelectedItem, () => IsEditEnabled);
            DeleteCommand = new RelayCommand(DeleteSelectedItem, () => IsDeleteEnabled);
            SaveCommand = new RelayCommand(SaveChanges);
        }
    }
}
