using System.Windows.Controls;
using Apllication4Course.ViewModels;

namespace Apllication4Course.Pages
{
    public partial class PaymentMethodPage : Page
    {
        public PaymentMethodPage()
        {
            InitializeComponent();
            DataContext = new PaymentMethodViewModel();
        }
    }
}
