using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Apllication4Course.Pages;
using Apllication4Course.Views;
using GalaSoft.MvvmLight.Command;

namespace Apllication4Course.ViewModels
{
    public class DataViewModel : BaseViewModel
    {
        private readonly Frame _mainFrame;
        private IBaseDataViewModel _currentPageViewModel;


        // Свойства для видимости кнопок
        private bool _isAddButtonVisible = true;
        private bool _isEditButtonVisible = true;
        private bool _isDeleteButtonVisible = true;
        private bool _isConfirmButtonVisible = false;

        public bool IsAddButtonVisible
        {
            get => _isAddButtonVisible;
            set => Set(ref _isAddButtonVisible, value);
        }

        public bool IsEditButtonVisible
        {
            get => _isEditButtonVisible;
            set => Set(ref _isEditButtonVisible, value);
        }

        public bool IsDeleteButtonVisible
        {
            get => _isDeleteButtonVisible;
            set => Set(ref _isDeleteButtonVisible, value);
        }

        public bool IsConfirmButtonVisible
        {
            get => _isConfirmButtonVisible;
            set => Set(ref _isConfirmButtonVisible, value);
        }

        public IBaseDataViewModel CurrentPageViewModel
        {
            get => _currentPageViewModel;
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged(nameof(CurrentPageViewModel));
                }
            }
        }

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
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            CloseCurrentWindow();
        }

        private void ExecuteLogout()
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        private void ExecuteNavigate(string pageName)
        {
            switch (pageName)
            {
                case "Services":
                    CurrentPageViewModel = new ServiceViewModel();
                    _mainFrame.Navigate(new ServicesPage { DataContext = CurrentPageViewModel });
                    break;

                case "Storage":
                    CurrentPageViewModel = new StorageViewModel();
                    _mainFrame.Navigate(new StoragePage { DataContext = CurrentPageViewModel });
                    break;

                case "Deceased":
                    CurrentPageViewModel = new DeceasedViewModel();
                    _mainFrame.Navigate(new DeceasedPage());
                    break;

                case "Employees":
                    CurrentPageViewModel = new EmployeeViewModel();
                    _mainFrame.Navigate(new EmployeesPage());
                    break;

                case "StorageLocations":
                    CurrentPageViewModel = new StorageLocationViewModel();
                    _mainFrame.Navigate(new StorageLocationsPage());
                    break;
            }
        }

        private void CloseCurrentWindow()
        {
            foreach (var window in Application.Current.Windows)
                if (window is DataWindow dataWindow)
                {
                    dataWindow.Close();
                    break;
                }
        }
    }
}