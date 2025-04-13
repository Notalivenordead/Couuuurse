using Apllication4Course.ViewModels;
using System.Windows.Controls;

namespace Apllication4Course.Pages
{
    public partial class FinancialOperationPage : Page
    {
        public FinancialOperationPage()
        {
            InitializeComponent();
            DataContext = new FinancialOperationViewModel();
        }
    }
}
