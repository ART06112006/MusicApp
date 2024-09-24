using MusicApp.ViewModels;
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
    /// Interaction logic for UserMainView.xaml
    /// </summary>
    public partial class UserMainView : Window
    {
        public UserMainViewModel ViewModel { get; set; }
        public UserMainView(UserMainViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = ViewModel;
        }

        private void ComboBoxNew_Selected(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;

            if (comboBox != null && ViewModel != null)
            {
                if ((comboBox.SelectedItem as ComboBoxItem)?.Content.ToString() == "New")
                {
                    ViewModel.NewContent = true;
                }
                else if ((comboBox.SelectedItem as ComboBoxItem)?.Content.ToString() == "Old")
                {
                    ViewModel.NewContent = false;
                }
                else
                {
                    ViewModel.NewContent = null;
                }
            }
        }

        private void ComboBoxPopular_Selected(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;

            if (comboBox != null && ViewModel != null)
            {
                if ((comboBox.SelectedItem as ComboBoxItem)?.Content.ToString() == "Most popular")
                {
                    ViewModel.PopularContent = true;
                }
                else if ((comboBox.SelectedItem as ComboBoxItem)?.Content.ToString() == "Least popular")
                {
                    ViewModel.PopularContent = false;
                }
                else
                {
                    ViewModel.PopularContent = null;
                }
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var selectedTabItem = e.AddedItems[0] as TabItem;
                if (selectedTabItem != null)
                {
                    if (selectedTabItem.Header.ToString() == "My albums")
                    {
                        ViewModel.RefreshMyAlbums();
                    }
                }
            }
        }
    }
}
