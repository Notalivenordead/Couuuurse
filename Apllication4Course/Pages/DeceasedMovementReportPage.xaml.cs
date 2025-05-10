using System.Windows.Controls;
using Apllication4Course.ViewModels;

namespace Apllication4Course.Pages
{
    public partial class DeceasedMovementReportPage : Page
    {
        public DeceasedMovementReportPage()
        {
            InitializeComponent();
            DataContext = new DeceasedMovementReportViewModel();
        }
    }
}