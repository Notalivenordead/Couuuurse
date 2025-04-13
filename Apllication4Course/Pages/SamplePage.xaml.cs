using System.Windows.Controls;
using Apllication4Course.ViewModels;

namespace Apllication4Course.Pages
{
    public partial class SamplePage : Page
    {
        public SamplePage()
        {
            InitializeComponent();
            DataContext = new SampleViewModel();
        }
    }
}
