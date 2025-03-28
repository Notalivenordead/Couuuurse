﻿using System.Collections.ObjectModel;
using Apllication4Course.Models;
using Apllication4Course.Services;
using System.Data.Entity;
using System.Linq;

namespace Apllication4Course.ViewModels
{
    public class StorageLocationViewModel : BaseDataViewModel<Места_В_Камерах>
    {
        public ObservableCollection<Места_В_Камерах> StorageLocations => Items as ObservableCollection<Места_В_Камерах>;

    }
}