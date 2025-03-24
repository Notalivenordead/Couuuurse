using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Apllication4Course.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void ShowErrorMessage(string message)
        {
            MessageBox.Show(
                message,                
                "Ошибка",              
                MessageBoxButton.OK,     
                MessageBoxImage.Error   
            );
        }

        protected void ShowSuccessMessage(string message)
        {
            MessageBox.Show(
                message,
                "Успех",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );
        }
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}