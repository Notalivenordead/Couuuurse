using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Apllication4Course.Services;
using Apllication4Course.Views;
using System.ComponentModel.DataAnnotations;

namespace Apllication4Course.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly UserService _userService;
        private string _login;
        private string _password;
        private string _errorMessage;

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand GoToRegisterCommand { get; }

        public LoginViewModel()
        {
            _userService = new UserService(DatabaseContext.Instance);
            LoginCommand = new RelayCommand(LoginExecute);
            GoToRegisterCommand = new RelayCommand(GoToRegisterExecute);
        }

        private void LoginExecute()
        {
            int IsLogabble = CanLoginExecute2(Login, Password);
            switch (IsLogabble)
            {
                case -1:
                    ErrorMessage = "Заполните поля логин и пароль";
                    ShowErrorMessage(ErrorMessage);
                    break;
                case 1:
                    ErrorMessage = "Успешная авторизация!";
                    ShowSuccessMessage(ErrorMessage);
                    var mainWindow = new MainWindow();
                    mainWindow.Show();
                    CloseCurrentWindow();
                    break;
                case 0:
                    ErrorMessage = "Неверный логин или пароль";
                    ShowErrorMessage(ErrorMessage);
                    break;
            }

        }

        // Модуль для автотестов авторизации
        public int CanLoginExecute2(string login, string password)
        {
            if (!CanLoginExecute(login, password))
                return -1;
            else
                if (_userService.Authenticate(login, password))
                    return 1;
                else
                    return 0;
        }

        private bool CanLoginExecute(string login, string password) => !string.IsNullOrWhiteSpace(login) && !string.IsNullOrWhiteSpace(password);

        private void GoToRegisterExecute()
        {
            var registerWindow = new Views.RegisterWindow();
            registerWindow.Show();
            CloseCurrentWindow();
        }

        private void CloseCurrentWindow()
        {
            foreach (var window in System.Windows.Application.Current.Windows)
                if (window is LoginWindow loginWindow)
                {
                    loginWindow.Close();
                    break;
                }
        }
    }
}