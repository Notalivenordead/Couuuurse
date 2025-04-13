using System.Windows.Controls;
using Apllication4Course.ViewModels;

namespace Apllication4Course.Pages
{
    public partial class InventoryUsagePage : Page
    {
        public InventoryUsagePage()
        {
            InitializeComponent();
            DataContext = new InventoryUsageViewModel();
        }
    }
}
