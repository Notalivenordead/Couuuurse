using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Apllication4Course.ViewModels;

namespace Apllication4Course.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            Closed += Window_Closed;
            DataContext = new LoginViewModel();
        }


        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.PasswordBox passwordBox && DataContext is LoginViewModel viewModel)
            {
                viewModel.Password = passwordBox.Password;

                if (VisiblePasswordTextBox != null && VisiblePasswordTextBox.Visibility == Visibility.Visible)
                    VisiblePasswordTextBox.Text = passwordBox.Password;
            }
        }

        private void EyeToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.Primitives.ToggleButton toggleButton && PasswordBox != null)
                if (toggleButton.IsChecked == true)
                {
                    VisiblePasswordTextBox.Text = PasswordBox.Password;
                    VisiblePasswordTextBox.Visibility = Visibility.Visible;

                    PasswordBox.Visibility = Visibility.Collapsed;
                }
                else
                {
                    PasswordBox.Password = VisiblePasswordTextBox.Text;
                    PasswordBox.Visibility = Visibility.Visible;

                    VisiblePasswordTextBox.Visibility = Visibility.Collapsed;
                }
        }

        private void VisiblePasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox && PasswordBox != null)
                PasswordBox.Password = textBox.Text;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (Application.Current.Windows.Cast<Window>().All(window => window.Visibility != Visibility.Visible))
                Application.Current.Shutdown();
        }
    }
}