using MusicApp.ViewModels;
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

namespace MusicApp.Views
{
    /// <summary>
    /// Interaction logic for SignUpView.xaml
    /// </summary>
    public partial class SignUpView : Window
    {
        public SignUpViewModel ViewModel { get; set; }
        public SignUpView(SignUpViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            ViewModel.CloseWindow += () => { Close(); };
            DataContext = ViewModel;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ViewModel.Password = PasswordBox.Password;
            ViewModel.ConfirmPassword = ConfirmPasswordBox.Password;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;

            if (radioButton != null && ViewModel != null)
            {
                if (radioButton.Content.ToString() == "Admin")
                {
                    ViewModel.IsAdmin = true;
                }
                else if (radioButton.Content.ToString() == "User")
                {
                    ViewModel.IsAdmin = false;
                }
            }
        }
    }
}
