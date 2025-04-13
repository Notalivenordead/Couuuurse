using System.Collections.ObjectModel;
using Apllication4Course.Models;

namespace Apllication4Course.ViewModels
{
    public class StorageLocationViewModel : BaseDataViewModel<Места_В_Камерах>
    {
        public ObservableCollection<Места_В_Камерах> StorageLocations => Items;

        public StorageLocationViewModel()
        {
            AddCommand = new RelayCommand(AddNewItem);
            EditCommand = new RelayCommand(EditSelectedItem, () => IsEditEnabled);
            DeleteCommand = new RelayCommand(DeleteSelectedItem, () => IsDeleteEnabled);
            SaveCommand = new RelayCommand(SaveChanges);
        }
    }
}
