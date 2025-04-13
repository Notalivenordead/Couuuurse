using Apllication4Course.Services;
using Apllication4Course.Views;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;

namespace Apllication4Course.ViewModels
{
    public class BaseDataViewModel<T> : BaseViewModel, IBaseDataViewModel where T : class, new()
    {
        protected ObservableCollection<T> _items;
        protected T _itemToEdit;
        protected T _itemToDelete;
        protected T _selectedItem;

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
            var itemsList = context.Set<T>().ToList();
            _items = new ObservableCollection<T>(itemsList);
        }

        protected virtual void AddNewItem()
        {
            Debug.WriteLine("Создание новой записи");
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
            Debug.WriteLine("Редактирование выбраной записи");

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
            Debug.WriteLine("Удаление выбраной записи");

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
                {
                    context.Set<T>().Add(SelectedItem);
                    Items.Add(SelectedItem);
                    SelectedItem = null;
                    ShowSuccessMessage("Добавлен новая запись");
                }

                if (_isModified && _itemToEdit != null)
                {
                    var entry = context.Entry(_itemToEdit);

                    if (entry.State == EntityState.Detached)
                        context.Set<T>().Attach(_itemToEdit);
                    entry.State = EntityState.Modified;
                    _isModified = false;
                    _itemToEdit = null;
                    SelectedItem = null;
                    ShowSuccessMessage("Выбранная запись была отредактирована.");
                }


                if (_itemToDelete != null)
                {
                    // сначала проверяем, есть ли сущность в контексте
                    var entry = context.Entry(_itemToDelete);
                    if (entry.State == EntityState.Detached)
                    {
                        // Если сущность не отслеживается, пробуем найти её в БД по ключу
                        var key = GetEntityKey(_itemToDelete);
                        if (key != null)
                        {
                            var existingEntity = context.Set<T>().Find(key);
                            if (existingEntity != null)
                            {
                                context.Set<T>().Remove(existingEntity);
                                Items.Remove(_itemToDelete);
                            }
                        }
                    }
                    else
                    {
                        context.Set<T>().Remove(_itemToDelete);
                        Items.Remove(_itemToDelete);
                    }
                    _itemToDelete = null;
                    SelectedItem = null;
                    ShowSuccessMessage("Выбранная запись была удалена.");
                }

                context.SaveChanges();

                var mainWindow = App.Current.MainWindow;
                if (mainWindow != null && mainWindow.DataContext is DataViewModel dataViewModel)
                    dataViewModel.IsConfirmButtonVisible = false;
                else
                    Debug.WriteLine("MainWindow или DataContext не инициализированы.");
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
            finally
            {
                LoadData();
            }
        }

        protected object[] GetEntityKey(T entity)
        {
            var _context = DatabaseContext.Instance;
            var objectContext = ((IObjectContextAdapter)_context).ObjectContext;
            var objectSet = objectContext.CreateObjectSet<T>();
            var keyNames = objectSet.EntitySet.ElementType.KeyMembers.Select(k => k.Name).ToArray();

            var keyValues = new object[keyNames.Length];
            var entityType = typeof(T);

            for (int i = 0; i < keyNames.Length; i++)
            {
                var prop = entityType.GetProperty(keyNames[i]);
                keyValues[i] = prop?.GetValue(entity);
            }

            return keyValues;
        }
    }
}