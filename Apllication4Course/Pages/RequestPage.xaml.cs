﻿using System.Windows.Controls;
using Apllication4Course.ViewModels;

namespace Apllication4Course.Pages
{
    public partial class RequestPage : Page
    {
        public RequestPage()
        {
            InitializeComponent();
            DataContext = new RequestViewModel();
        }
    }
}
