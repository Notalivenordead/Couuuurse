using Apllication4Course.Pages;
using Apllication4Course.ViewModels;
using System.Windows;

namespace Apllication4Course.Views
{
    public partial class DataWindow : Window
    {
        public DataWindow()
        {
            InitializeComponent();
            var viewModel = new DataViewModel(MainFrame); // Передаем ссылку на Frame
            DataContext = viewModel;
            MainFrame.Navigate(new ServicesPage());
        }
    }
}