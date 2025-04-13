using System.Collections.ObjectModel;
using Apllication4Course.Models;

namespace Apllication4Course.ViewModels
{
    public class PaymentMethodViewModel : BaseDataViewModel<Способ_Оплаты>
    {
        public ObservableCollection<Способ_Оплаты> PaymentMethods => Items;
        public PaymentMethodViewModel()
        {
            AddCommand = new RelayCommand(AddNewItem);
            EditCommand = new RelayCommand(EditSelectedItem, () => IsEditEnabled);
            DeleteCommand = new RelayCommand(DeleteSelectedItem, () => IsDeleteEnabled);
            SaveCommand = new RelayCommand(SaveChanges);
        }
    }
}
