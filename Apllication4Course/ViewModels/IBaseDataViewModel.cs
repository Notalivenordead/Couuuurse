﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Apllication4Course.ViewModels
{
    public interface IBaseDataViewModel
    {
        ICommand AddCommand { get; }
        ICommand EditCommand { get; }
        ICommand DeleteCommand { get; }
        ICommand SaveCommand { get; }

        bool IsEditEnabled { get; }
        bool IsDeleteEnabled { get; }
    }
}
