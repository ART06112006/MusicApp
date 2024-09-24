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
    /// Interaction logic for UserTopUpAccountView.xaml
    /// </summary>
    public partial class UserTopUpAccountView : Window
    {
        public UserTopUpAccountViewModel ViewModel { get; set; }
        public UserTopUpAccountView(UserTopUpAccountViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = ViewModel;
        }
    }
}
