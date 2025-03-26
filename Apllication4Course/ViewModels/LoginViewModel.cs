using System;
using System.Drawing;
using System.IO;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Apllication4Course.Services;
using Apllication4Course.Views;
using System.Linq;
using System.Windows;

namespace Apllication4Course.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly UserService _userService;
        private string _login;
        private string _password;
        private string _captchaText;
        private string _userCaptchaInput;
        private byte[] _captchaImageBytes;
        private int _failedAttempts = 0;
        private int _failedAttemptsCapcha = 0;
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

        public string UserCaptchaInput
        {
            get => _userCaptchaInput;
            set
            {
                _userCaptchaInput = value;
                OnPropertyChanged(nameof(UserCaptchaInput));
            }
        }

        public byte[] CaptchaImageBytes
        {
            get => _captchaImageBytes;
            set
            {
                _captchaImageBytes = value;
                OnPropertyChanged(nameof(CaptchaImageBytes));
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
        public ICommand RefreshCaptchaCommand { get; }


        public LoginViewModel()
        {
            _userService = new UserService(DatabaseContext.Instance);
            LoginCommand = new RelayCommand(LoginExecute);
            GoToRegisterCommand = new RelayCommand(GoToRegisterExecute);
            RefreshCaptchaCommand = new RelayCommand(GenerateCaptcha);
        }

        private void LoginExecute()
        {
            if (_failedAttempts >= 3 && (string.IsNullOrEmpty(UserCaptchaInput) || !UserCaptchaInput.Equals(_captchaText, StringComparison.OrdinalIgnoreCase)))
            {
                _failedAttemptsCapcha += 1;
                if (_failedAttemptsCapcha >= 3)
                {
                    ShowErrorMessage("Вы исчерпали количество попыток для ввода");
                    Application.Current.Shutdown();
                }
                ErrorMessage = "Неверная капча";
                ShowErrorMessage(ErrorMessage);
                GenerateCaptcha();
                return;
            }

            int IsLoggable = CanLoginExecute2(Login, Password);
            switch (IsLoggable)
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
                    _failedAttempts++;
                    if (_failedAttempts >= 3)
                        GenerateCaptcha();
                    break;
            }
        }

        public int CapchaValidate(string inserted_capcha, string text_capcha, int mistakes)
        {
            if (string.IsNullOrWhiteSpace(text_capcha)) return 0;
            if (mistakes >= 3) return -1;
            if (inserted_capcha == text_capcha && mistakes < 3) return 1;
            if (inserted_capcha != text_capcha && mistakes < 3) return -2;
            else return -100;
        }

        public int CanLoginExecute2(string login, string password)
        {
            if (!CanLoginExecute(login, password))
                return -1;
            else if (_userService.Authenticate(login, password))
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

        private void GenerateCaptcha()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            _captchaText = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());

            using (Bitmap bitmap = new Bitmap(150, 50))
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(System.Drawing.Color.White);
                using (Font font = new Font("Arial", 20, System.Drawing.FontStyle.Bold))
                {
                    graphics.DrawString(_captchaText, font, brush: System.Drawing.Brushes.Black, new PointF(10, 10));

                    // Добавляем шум
                    for (int i = 0; i < 200; i++)
                    {
                        int x = random.Next(bitmap.Width);
                        int y = random.Next(bitmap.Height);
                        bitmap.SetPixel(x, y, System.Drawing.Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));
                    }
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    CaptchaImageBytes = ms.ToArray();
                }
            }
        }
    }
}