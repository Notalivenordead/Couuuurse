using System.Collections.ObjectModel;
using System.Linq;
using Apllication4Course.Models;
using Apllication4Course.Services;

namespace Apllication4Course.ViewModels
{
    public class TemperatureLogViewModel : BaseDataViewModel<Журнал_Температур>
    {
        public ObservableCollection<Журнал_Температур> Storage => Items as ObservableCollection<Журнал_Температур>;

        public TemperatureLogViewModel()
        {
            AddCommand = new RelayCommand(AddNewItem);
            EditCommand = new RelayCommand(EditSelectedItem, () => IsEditEnabled);
            DeleteCommand = new RelayCommand(DeleteSelectedItem, () => IsDeleteEnabled);
            SaveCommand = new RelayCommand(SaveChanges);
        }
    }
}