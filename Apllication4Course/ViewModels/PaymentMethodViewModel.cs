using System.Collections.ObjectModel;
using System.Linq;
using Apllication4Course.Models;
using Apllication4Course.Services;

namespace Apllication4Course.ViewModels
{
    public class PaymentMethodViewModel : BaseViewModel
    {
        public ObservableCollection<Способ_Оплаты> PaymentMethods { get; set; }

        public PaymentMethodViewModel()
        {
            using (var context = DatabaseContext.Instance)
            {
                PaymentMethods = new ObservableCollection<Способ_Оплаты>(context.СпособОплаты.ToList());
            }
        }
    }
}