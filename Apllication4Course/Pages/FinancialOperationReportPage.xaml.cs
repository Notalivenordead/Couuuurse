using Apllication4Course.ViewModels;
using System.Windows.Controls;

namespace Apllication4Course.Pages
{
    public partial class FinancialOperationReportPage : Page
    {
        public FinancialOperationReportPage()
        {
            InitializeComponent();
            DataContext = new FinancialOperationReportViewModel();
        }
    }
}
