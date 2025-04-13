using System.Windows.Controls;
using Apllication4Course.ViewModels;

namespace Apllication4Course.Pages
{
    public partial class ResearchPage : Page
    {
        public ResearchPage()
        {
            InitializeComponent();
            DataContext = new ResearchViewModel();
        }
    }
}
