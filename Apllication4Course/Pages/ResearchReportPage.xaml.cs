using Apllication4Course.ViewModels;
using System.Windows.Controls;

namespace Apllication4Course.Pages
{
    public partial class ResearchReportPage : Page
    {
        public ResearchReportPage()
        {
            InitializeComponent();
            DataContext = new ResearchReportViewModel();
        }
    }
}
