﻿using MusicApp.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MusicApp.Views.UserView
{
    /// <summary>
    /// Interaction logic for UserShowMyAlbumView.xaml
    /// </summary>
    public partial class UserShowMyAlbumView : Window
    {
        public UserShowMyAlbumViewModel ViewModel { get; set; }
        public UserShowMyAlbumView(UserShowMyAlbumViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = ViewModel;
        }
    }
}
