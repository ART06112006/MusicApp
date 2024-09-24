using MusicApp.Infrastructure;
using MusicApp.Models;
using MusicApp.Services;
using MusicApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicApp.Commands
{
    public class SignUpUserCommand : BaseCommand
    {
        public SignUpViewModel ViewModel { get; set; }

        public override bool CanExecute(object parameter)
        {
            if (parameter != null && ViewModel == null)
            {
                ViewModel = parameter as SignUpViewModel;
                ViewModel.PropertyChanged += OnViewModelPropertyChanged;
            }

            return ViewModel != null &&
                !string.IsNullOrEmpty(ViewModel.Name) &&
                !string.IsNullOrEmpty(ViewModel.Surname) &&
                ViewModel.Year > 0 &&
                !string.IsNullOrEmpty(ViewModel.Login) &&
                ViewModel.Email.Contains("@gmail.com") &&
                ViewModel.Email.Length > 10 &&
                !string.IsNullOrEmpty(ViewModel.Password) &&
                ViewModel.Password.Length > 4 &&
                !string.IsNullOrEmpty(ViewModel.ConfirmPassword) &&
                ViewModel.Password == ViewModel.ConfirmPassword;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewModel.Name) ||
                e.PropertyName == nameof(ViewModel.Surname) ||
                e.PropertyName == nameof(ViewModel.Year) ||
                e.PropertyName == nameof(ViewModel.Login) ||
                e.PropertyName == nameof(ViewModel.Email) ||
                e.PropertyName == nameof(ViewModel.Password) ||
                e.PropertyName == nameof(ViewModel.ConfirmPassword))
            {
                OnCanExecuteChanged();
            }
        }

        public override void Execute(object parameter)
        {
            var authService = (AuthorizationService)(AppServiceProvider.ServiceProvider.GetService(typeof(AuthorizationService)));

            var user = new User()
            {
                Name = ViewModel.Name,
                Surname = ViewModel.Surname,
                Year = ViewModel.Year,
                Login = ViewModel.Login,
                Email = ViewModel.Email,
                Password = HasherService.HashPassword(ViewModel.Password),
                IsAdmin = ViewModel.IsAdmin,
                Balance = 0
            };

            if (authService.RegisterUser(user))
            {
                MessageBox.Show("User was signed up successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("User was not signed up!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            ViewModel.CloseWindow();
        }
    }
}
