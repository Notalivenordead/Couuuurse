using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Apllication4Course.Pages;
using Apllication4Course.Views;
using System.Windows;


namespace Apllication4Course.ViewModels
{
    public class DataViewModel : BaseViewModel
    {
        private readonly Frame _mainFrame;

        // Экземпляры страниц
        private ServicesPage _servicesPage;
        private StoragePage _storagePage;
        private DeceasedPage _deceasedPage;
        private EmployeesPage _employeesPage;
        private StorageLocationsPage _storageLocationsPage;

        public ICommand GoToMainCommand { get; }
        public ICommand LogoutCommand { get; }

        public ICommand NavigateCommand { get; }

        public DataViewModel(Frame mainFrame)
        {
            _mainFrame = mainFrame;
            GoToMainCommand = new RelayCommand(ExecuteGoToMain);
            NavigateCommand = new RelayCommand<string>(ExecuteNavigate);
            LogoutCommand = new RelayCommand(ExecuteLogout);
        }

        private void ExecuteGoToMain()
        {
            // Вернуться на главное окно
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            CloseCurrentWindow();
        }


        private void ExecuteLogout()
        {
            // Диалоговое окно подтверждения выхода
            var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void ExecuteNavigate(string pageName)
        {
            switch (pageName)
            {
                case "Services":
                    if (_servicesPage == null)
                    {
                        _servicesPage = new ServicesPage();
                    }
                    _mainFrame.Navigate(_servicesPage);
                    break;

                case "Storage":
                    if (_storagePage == null)
                    {
                        _storagePage = new StoragePage();
                    }
                    _mainFrame.Navigate(_storagePage);
                    break;

                case "Deceased":
                    if (_deceasedPage == null)
                    {
                        _deceasedPage = new DeceasedPage();
                    }
                    _mainFrame.Navigate(_deceasedPage);
                    break;

                case "Employees":
                    if (_employeesPage == null)
                    {
                        _employeesPage = new EmployeesPage();
                    }
                    _mainFrame.Navigate(_employeesPage);
                    break;

                case "StorageLocations":
                    if (_storageLocationsPage == null)
                    {
                        _storageLocationsPage = new StorageLocationsPage();
                    }
                    _mainFrame.Navigate(_storageLocationsPage);
                    break;
            }
        }
        private void CloseCurrentWindow()
        {
            foreach (var window in Application.Current.Windows)
                if (window is DataWindow DataWindow)
                {
                    DataWindow.Close();
                    break;
                }
        }
    }
}