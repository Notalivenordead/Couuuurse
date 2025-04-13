using Apllication4Course.ViewModels;
using System.Windows.Controls;

namespace Apllication4Course.Pages
{
    public partial class ComplaintLogPage : Page
    {
        public ComplaintLogPage()
        {
            InitializeComponent();
            DataContext = new ComplaintLogViewModel();

        }
    }
}
