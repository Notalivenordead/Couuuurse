using System.Windows.Controls;
using Apllication4Course.ViewModels;

namespace Apllication4Course.Pages
{
    public partial class TransportationPage : Page
    {
        public TransportationPage()
        {
            InitializeComponent();
            DataContext = new TransportationViewModel();
        }
    }
}
