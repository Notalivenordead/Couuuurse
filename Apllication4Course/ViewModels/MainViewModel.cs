using System.Windows;
using System.Windows.Input;
using Apllication4Course.Services;
using Apllication4Course.Views;

namespace Apllication4Course.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand ViewDataCommand { get; }
        public ICommand LogoutCommand { get; }
        public ICommand GoToLoginCommand { get; }

        public MainViewModel()
        {
            ViewDataCommand = new RelayCommand(ExecuteViewData);
            LogoutCommand = new RelayCommand(ExecuteLogout);
            GoToLoginCommand = new RelayCommand(ExecuteGoToLogin);
        }

        private void ExecuteViewData()
        {
            // Открыть окно просмотра данных
            DataWindow dataWindow = new DataWindow();
            dataWindow.Show();
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

        private void ExecuteGoToLogin()
        {
            // Вернуться на окно авторизации
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            CloseCurrentWindow();
        }

        private void CloseCurrentWindow()
        {
            foreach (var window in Application.Current.Windows)
                if (window is MainWindow MainWindow)
                {
                    MainWindow.Close();
                    break;
                }
        }
    }
}