using System.Windows.Controls;
using Apllication4Course.ViewModels;

namespace Apllication4Course.Pages
{
    public partial class StorageLocationsPage : Page
    {
        public StorageLocationsPage()
        {
            InitializeComponent();
            DataContext = new StorageLocationViewModel();
        }
    }
}