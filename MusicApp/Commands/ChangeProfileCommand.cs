using MusicApp.Infrastructure;
using MusicApp.Services;
using MusicApp.ViewModels;
using MusicApp.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicApp.Commands
{
    public class ChangeProfileCommand : BaseCommand
    {
        public ProfileViewModel ViewModel { get; set; }

        public override bool CanExecute(object parameter)
        {
            if (parameter != null && ViewModel == null)
            {
                ViewModel = parameter as ProfileViewModel;
                ViewModel.PropertyChanged += OnViewModelPropertyChanged;
            }

            return ViewModel != null &&
                !string.IsNullOrEmpty(ViewModel.Name) &&
                !string.IsNullOrEmpty(ViewModel.Surname) &&
                ViewModel.Year > 0 &&
                ViewModel.Email.Contains("@gmail.com") &&
                ViewModel.Email.Length > 10;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewModel.Name) ||
                e.PropertyName == nameof(ViewModel.Surname) ||
                e.PropertyName == nameof(ViewModel.Year) ||
                e.PropertyName == nameof(ViewModel.Email))
            {
                OnCanExecuteChanged();
            }
        }

        public override void Execute(object parameter)
        {
            try
            {
                var userService = (UserService)(AppServiceProvider.ServiceProvider.GetService(typeof(UserService)));

                var user = userService.GetUserById(ViewModel.UserId);

                if (user != null)
                {
                    user.Name = ViewModel.Name;
                    user.Surname = ViewModel.Surname;
                    user.Year = ViewModel.Year;
                    user.Email = ViewModel.Email;

                    userService.UpdateUser(user);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Profile was not updated!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
