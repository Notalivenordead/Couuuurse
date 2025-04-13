using System.Collections.ObjectModel;
using Apllication4Course.Models;

namespace Apllication4Course.ViewModels
{
    public class PaidResearchViewModel : BaseDataViewModel<Платные_Исследования>
    {
        public ObservableCollection<Платные_Исследования> PaidResearches => Items;

        public PaidResearchViewModel() 
        {
            AddCommand = new RelayCommand(AddNewItem);
            EditCommand = new RelayCommand(EditSelectedItem, () => IsEditEnabled);
            DeleteCommand = new RelayCommand(DeleteSelectedItem, () => IsDeleteEnabled);
            SaveCommand = new RelayCommand(SaveChanges);
        }

    }
}
