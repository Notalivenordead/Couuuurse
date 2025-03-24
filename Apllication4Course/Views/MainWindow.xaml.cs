using System.Windows;
using Apllication4Course.ViewModels;

namespace Apllication4Course.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}