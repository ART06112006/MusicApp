using MusicApp.ViewModels.UserViewModels;
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
    /// Interaction logic for UserBuyAlbumView.xaml
    /// </summary>
    public partial class UserBuyAlbumView : Window
    {
        public UserBuyAlbumViewModel ViewModel { get; set; }
        public UserBuyAlbumView(UserBuyAlbumViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = ViewModel;
        }
    }
}
