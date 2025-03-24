using System.Windows.Controls;
using Apllication4Course.ViewModels;

namespace Apllication4Course.Pages
{
    public partial class DeceasedPage : Page
    {
        public DeceasedPage()
        {
            InitializeComponent();
            DataContext = new DeceasedViewModel();
        }
    }
}