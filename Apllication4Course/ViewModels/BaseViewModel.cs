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
        protected bool Set<T>(ref T field, T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

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