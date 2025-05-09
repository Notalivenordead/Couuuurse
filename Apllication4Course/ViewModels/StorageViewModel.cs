﻿using System.Collections.ObjectModel;
using Apllication4Course.Models;

namespace Apllication4Course.ViewModels
{
    public class StorageViewModel : BaseDataViewModel<Камеры_Хранения>
    {
        public ObservableCollection<Камеры_Хранения> Storage => Items;

        public StorageViewModel()
        {
            AddCommand = new RelayCommand(AddNewItem);
            EditCommand = new RelayCommand(EditSelectedItem, () => IsEditEnabled);
            DeleteCommand = new RelayCommand(DeleteSelectedItem, () => IsDeleteEnabled);
            SaveCommand = new RelayCommand(SaveChanges);
        }
    }
}
