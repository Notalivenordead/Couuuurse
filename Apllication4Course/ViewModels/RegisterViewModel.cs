using System.Text.RegularExpressions;
using System.Windows.Input;
using Apllication4Course.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Apllication4Course.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly UserService _userService;
        private string _login;
        private string _password;
        private string _lastName;
        private string _firstName;
        private string _middleName;
        private string _position;
        private string _phone;
        private string _email;
        private string _errorMessage;


        public List<string> Positions { get; set; }
        public string Login
        {
            get => _login;
            set => Set(ref _login, value);
        }

        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        public string LastName
        {
            get => _lastName;
            set => Set(ref _lastName, value);
        }

        public string FirstName
        {
            get => _firstName;
            set => Set(ref _firstName, value);
        }

        public string MiddleName
        {
            get => _middleName;
            set => Set(ref _middleName, value);
        }

        public string Position
        {
            get => _position;
            set => Set(ref _position, value);
        }

        public string Phone
        {
            get => _phone;
            set => Set(ref _phone, value);
        }

        public string Email
        {
            get => _email;
            set => Set(ref _email, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => Set(ref _errorMessage, value);
        }

        public ICommand RegisterCommand { get; }
        public ICommand GoToLoginCommand { get; }

        public RegisterViewModel(UserService userService)
        {
            _userService = userService;
            Positions = new List<string>
            {
                "Лаборант",
                "Патологоанатом",
                "Администратор",
                "Руководство"
            };
    
            RegisterCommand = new RelayCommand(RegisterExecute);
            GoToLoginCommand = new RelayCommand(GoToLoginExecute);
        }

        public bool IsPasswordStrong(string password)
        {
                ErrorMessage = "Пароль не содержит:\n";
                var specialSymbols = "!@#$%^&*()-_+=<>?/[]{}|";
                int specialSymbolCount = password.Count(ch => specialSymbols.Contains(ch));

                if (password.Count(char.IsUpper) < 2) ErrorMessage += "2 заглавные буквы\n";

                if (password.Count(char.IsLower) < 2) ErrorMessage += "2 строчные буквы\n";

                if (password.Count(char.IsDigit) < 2) ErrorMessage += "2 цифры\n";

                if (specialSymbolCount < 2) ErrorMessage += "2 специальных символа";
                return false;
        }
        private void RegisterExecute()
        {
            int availability = CheckRegister(Login, Password, LastName, FirstName, Position, Phone, MiddleName, Email);
            switch (availability)
            {
                case -1:
                    ErrorMessage = "Заполните все обязательные поля.";
                    ShowErrorMessage(ErrorMessage);
                    return;
                case -2:
                    IsPasswordStrong(Password);
                    ShowErrorMessage(ErrorMessage);
                    ErrorMessage = string.Empty;
                    return;
                case -3:
                    ErrorMessage = "Дан неверный почтовый адрес. Пример верного:\nexample@mail.com";
                    ShowErrorMessage(ErrorMessage);
                    return;
                case -4:
                    ErrorMessage = "Дан неверный неверный номер телефона. Пример верного:\n+79867077878";
                    ShowErrorMessage(ErrorMessage);
                    return;
                case 1:
                    ErrorMessage = "Регистрация успешна!";
                    ShowSuccessMessage(ErrorMessage);
                    GoToLoginExecute();
                    break;
                case -5:
                    ErrorMessage = "Пользователь с таким логином уже существует.";
                    ShowErrorMessage(ErrorMessage);
                    return;
                case 0:
                    ShowErrorMessage(ErrorMessage);
                    return;
            }
        }
        public int CheckRegister(string login, string password, string Lastname, string Firstname, string position, string phone,
            string FatherName = null, string email = null)
        {
            if (!CanRegisterExecute(login, password, Lastname, Firstname, position, phone))
                return -1;
            if (!ValidatePassword(password))
                return -2;
            if (!ValidateEmail(email))
                return -3;
            if (!ValidatePhoneNumber(phone))
                return -4;
            try
                {
                    var user = new Models.Сотрудники
                    {
                        Логин = login,
                        ПарольHash = password,
                        ФИО = $"{Lastname} {Firstname} {FatherName}".Trim(),
                        Должность = position,
                        КонтактныйТелефон = phone,
                        Email = email
                    };
                    if (_userService.Register(user))
                        return 1;
                    else return -5;
                }
                catch (Exception ex)
                {
                    ErrorMessage = $"Ошибка регистрации: {ex.Message}";
                    return 0;
                }
        }

        private bool CanRegisterExecute(string login, string password, string Lastname, string Firstname,
            string position, string phone) =>
            !string.IsNullOrWhiteSpace(login) &&
            !string.IsNullOrWhiteSpace(password) &&
            !string.IsNullOrWhiteSpace(Lastname) &&
            !string.IsNullOrWhiteSpace(Firstname) &&
            !string.IsNullOrWhiteSpace(position) &&
            !string.IsNullOrWhiteSpace(phone);

        private void GoToLoginExecute()
        {
            var loginWindow = new Views.LoginWindow();
            loginWindow.Show();
            CloseCurrentWindow();
        }

        public bool ValidatePassword(string password)
        {
            var regex = new Regex(@"^(?=.*[!@#$%^&*()\-_=+<>?/\[\]{}|].*[!@#$%^&*()\-_=+<>?/\[\]{}|])" +
                       @"(?=.*[a-z].*[a-z])" + 
                       @"(?=.*[A-Z].*[A-Z])" + 
                       @"(?=.*\d.*\d)" +       
                       @".{8,}$");             
            return regex.IsMatch(password);
        }

        private bool ValidateEmail(string test)
        {
            if (string.IsNullOrWhiteSpace(test))
                return true;
            else
            {
                var regex = new Regex(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9_-]+$");
                return regex.IsMatch(test);
            }
        }
        public bool ValidatePhoneNumber(string test)
        {
            var regex = new Regex(@"^\+\d{11,12}$");
            return regex.IsMatch(test);
        }

        private void CloseCurrentWindow()
        {
            foreach (var window in System.Windows.Application.Current.Windows)
                if (window is Views.RegisterWindow registerWindow)
                {
                    registerWindow.Close();
                    break;
                }
        }
    }
}