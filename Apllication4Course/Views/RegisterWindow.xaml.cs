using Apllication4Course.Services;
using System.Windows;
using System.Windows.Controls;

namespace Apllication4Course.Views
{
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.RegisterViewModel(new Services.UserService());
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.PasswordBox passwordBox && DataContext is ViewModels.RegisterViewModel viewModel)
            {
                viewModel.Password = passwordBox.Password;

                if (VisiblePasswordTextBox != null && VisiblePasswordTextBox.Visibility == Visibility.Visible)
                    VisiblePasswordTextBox.Text = passwordBox.Password;
            }
        }

        private void EyeToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox == null || VisiblePasswordTextBox == null) return;

            if (PasswordBox.Visibility == Visibility.Visible)
            {
                VisiblePasswordTextBox.Text = PasswordBox.Password;
                PasswordBox.Visibility = Visibility.Collapsed;
                VisiblePasswordTextBox.Visibility = Visibility.Visible;
            }
            else
            {
                PasswordBox.Password = VisiblePasswordTextBox.Text;
                PasswordBox.Visibility = Visibility.Visible;
                VisiblePasswordTextBox.Visibility = Visibility.Collapsed;
            }
        }

        private void VisiblePasswordTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && PasswordBox != null)
                PasswordBox.Password = textBox.Text;
        }
    }
}