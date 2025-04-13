using System.Windows.Controls;
using Apllication4Course.ViewModels;

namespace Apllication4Course.Pages
{
    public partial class PaidResearchPage : Page
    {
        public PaidResearchPage()
        {
            InitializeComponent();
            DataContext = new PaidResearchViewModel();
        }
    }
}
