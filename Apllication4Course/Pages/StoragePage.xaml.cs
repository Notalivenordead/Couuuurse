using System.Windows.Controls;
using Apllication4Course.ViewModels;

namespace Apllication4Course.Pages
{
    public partial class StoragePage : Page
    {
        public StoragePage()
        {
            InitializeComponent();
            DataContext = new StorageViewModel();
        }
    }
}