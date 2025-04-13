using System.Windows.Controls;
using Apllication4Course.ViewModels;

namespace Apllication4Course.Pages
{
    public partial class SampleUsagePage : Page
    {
        public SampleUsagePage()
        {
            InitializeComponent();
            DataContext = new SampleUsageViewModel();
        }
    }
}
