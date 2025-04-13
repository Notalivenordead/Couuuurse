using Apllication4Course.Views;
using System.Windows;

namespace Apllication4Course
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainWindow = new DataWindow();
            MainWindow = mainWindow;
        }
    }
}
