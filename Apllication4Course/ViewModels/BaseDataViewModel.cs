using System.Collections.ObjectModel;
using System.Linq;
using Apllication4Course.Services;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System;
using System.Diagnostics;
using System.Data.Entity.Infrastructure;

namespace Apllication4Course.ViewModels
{
    public class BaseDataViewModel<T> : BaseViewModel, IBaseDataViewModel where T : class, new()
    {
        protected ObservableCollection<T> _items;
        private T _itemToEdit;
        private T _itemToDelete;
        private T _selectedItem;

        public ObservableCollection<T> Items
        {
            get
            {
                if (_items == null)
                {
                    LoadData();
                }
                return _items;
            }
        }

        public T SelectedItem
        {
            get => _selectedItem;
            set
            {
                Set(ref _selectedItem, value);
                OnPropertyChanged(nameof(IsEditEnabled));
                OnPropertyChanged(nameof(IsDeleteEnabled));
            }
        }

        public bool IsEditEnabled => SelectedItem != null;
        public bool IsDeleteEnabled => SelectedItem != null;
        private bool _isModified = false;

        public ICommand AddCommand { get; protected set; }
        public ICommand EditCommand { get; protected set; }
        public ICommand DeleteCommand { get; protected set; }
        public ICommand SaveCommand { get; protected set; }

        public BaseDataViewModel()
        {
            AddCommand = new RelayCommand(AddNewItem);
            EditCommand = new RelayCommand(EditSelectedItem, () => IsEditEnabled);
            DeleteCommand = new RelayCommand(DeleteSelectedItem, () => IsDeleteEnabled);
            SaveCommand = new RelayCommand(SaveChanges);
        }

        protected virtual void LoadData()
        {
            var context = DatabaseContext.Instance;
            var itemsList = context.Set<T>()
                .AsNoTracking()
                .ToList();
            _items = new ObservableCollection<T>(itemsList);
        }

        protected virtual void AddNewItem()
        {
            var newItem = new T();
            Items.Add(newItem);
            SelectedItem = newItem;

            _itemToEdit = null;
            _itemToDelete = null;
            _isModified = false;

            var mainWindow = App.Current.MainWindow;
            if (mainWindow != null && mainWindow.DataContext is DataViewModel dataViewModel)
                dataViewModel.IsConfirmButtonVisible = true;
            else
                Debug.WriteLine("MainWindow или DataContext не инициализированы.");
        }

        protected virtual void EditSelectedItem()
        {
            if (SelectedItem == null) return;

            _itemToEdit = SelectedItem;
            _itemToDelete = null;
            _isModified = true;

            var mainWindow = App.Current.MainWindow;
            if (mainWindow != null && mainWindow.DataContext is DataViewModel dataViewModel)
                dataViewModel.IsConfirmButtonVisible = true;
            else
                Debug.WriteLine("MainWindow или DataContext не инициализированы.");
        }

        protected virtual void DeleteSelectedItem()
        {
            if (SelectedItem == null) return;

            _itemToDelete = SelectedItem;
            _itemToEdit = null;
            _isModified = false;

            var mainWindow = App.Current.MainWindow;
            if (mainWindow != null && mainWindow.DataContext is DataViewModel dataViewModel)
                dataViewModel.IsConfirmButtonVisible = true;
            else
                Debug.WriteLine("MainWindow или DataContext не инициализированы.");
        }

        protected virtual void SaveChanges()
        {
            var context = DatabaseContext.Instance;
                try
                {
                    if (_itemToEdit == null && _itemToDelete == null && SelectedItem != null)
                        context.Set<T>().Add((T)SelectedItem);

                if (_isModified)
                {
                    foreach (var item in Items)
                        context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    _isModified = false;
                }


                if (_itemToDelete != null)
                    {
                    context.Set<T>().Remove(_itemToDelete);
                    Items.Remove(_itemToDelete);
                    _itemToDelete = null;
                    }

                    context.SaveChanges();

                    SelectedItem = Items.FirstOrDefault();

                    var mainWindow = App.Current.MainWindow;
                    if (mainWindow != null && mainWindow.DataContext is DataViewModel dataViewModel)
                        dataViewModel.IsConfirmButtonVisible = false;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    ShowErrorMessage($"Конфликт при обновлении данных: {ex.Message}");
                }
                catch (DbUpdateException ex)
                {
                    ShowErrorMessage($"Ошибка при обновлении данных: {ex.Message}");
                }
                catch (Exception ex)
                {
                    ShowErrorMessage($"Произошла ошибка: {ex.Message}");
                }
        }
    }
}