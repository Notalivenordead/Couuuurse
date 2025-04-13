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
            HideCurrentWindow();
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

                case "ComplaintLog":
                    CurrentPageViewModel = new ComplaintLogViewModel();
                    _mainFrame.Navigate(new ComplaintLogPage());
                    break;

                case "FinancialOperation":
                    CurrentPageViewModel = new FinancialOperationViewModel();
                    _mainFrame.Navigate(new FinancialOperationPage());
                    break;

                case "InventoryUsage":
                    CurrentPageViewModel = new InventoryUsageViewModel();
                    _mainFrame.Navigate(new InventoryUsagePage());
                    break;

                case "PaidResearch":
                    CurrentPageViewModel = new PaidResearchViewModel();
                    _mainFrame.Navigate(new PaidResearchPage());
                    break;

                case "Inventory":
                    CurrentPageViewModel = new InventoryViewModel();
                    _mainFrame.Navigate(new InventoryPage());
                    break;

                case "PaymentMethod":
                    CurrentPageViewModel = new PaymentMethodViewModel();
                    _mainFrame.Navigate(new PaymentMethodPage());
                    break;

                case "Request":
                    CurrentPageViewModel = new RequestViewModel();
                    _mainFrame.Navigate(new RequestPage());
                    break;

                case "Research":
                    CurrentPageViewModel = new ResearchViewModel();
                    _mainFrame.Navigate(new ResearchPage());
                    break;

                case "SampleUsage":
                    CurrentPageViewModel = new SampleUsageViewModel();
                    _mainFrame.Navigate(new SampleUsagePage());
                    break;

                case "Sample":
                    CurrentPageViewModel = new SampleViewModel();
                    _mainFrame.Navigate(new SamplePage());
                    break;

                case "TemperatureLog":
                    CurrentPageViewModel = new TemperatureLogViewModel();
                    _mainFrame.Navigate(new TemperatureLogPage());
                    break;

                case "Transportation":
                    CurrentPageViewModel = new TransportationViewModel();
                    _mainFrame.Navigate(new TransportationPage());
                    break;
            }
        }

        private void HideCurrentWindow()
        {
            foreach (var window in Application.Current.Windows)
                if (window is DataWindow dataWindow)
                {
                    dataWindow.Hide();
                    break;
                }
        }
    }
}