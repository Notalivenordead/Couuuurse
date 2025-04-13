using Apllication4Course.ViewModels;
using System.Windows.Controls;


namespace Apllication4Course.Pages
{
    public partial class InventoryPage : Page
    {
        public InventoryPage()
        {
            InitializeComponent();
            DataContext = new InventoryViewModel();
        }
    }
}
