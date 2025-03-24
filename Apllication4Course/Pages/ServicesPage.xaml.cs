using Apllication4Course.ViewModels;
using System.Windows.Controls;

namespace Apllication4Course.Pages
{
    public partial class ServicesPage : Page
    {
        public ServicesPage()
        {
            InitializeComponent();
            DataContext = new ServiceViewModel();
        }
    }
}