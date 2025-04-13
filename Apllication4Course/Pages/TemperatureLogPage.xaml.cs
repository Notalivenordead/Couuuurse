using System.Windows.Controls;
using Apllication4Course.ViewModels;

namespace Apllication4Course.Pages
{
    public partial class TemperatureLogPage : Page
    {
        public TemperatureLogPage()
        {
            InitializeComponent();
            DataContext = new TemperatureLogViewModel();
        }
    }
}
