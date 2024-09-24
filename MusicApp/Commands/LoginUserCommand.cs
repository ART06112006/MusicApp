using MusicApp.Infrastructure;
using MusicApp.Services;
using MusicApp.ViewModels;
using MusicApp.ViewModels.UserViewModels;
using MusicApp.Views;
using MusicApp.Views.UserView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicApp.Commands
{
    public class LoginUserCommand : BaseCommand
    {
        public LoginViewModel ViewModel { get; set; }

        public override bool CanExecute(object parameter)
        {
            if (parameter != null && ViewModel == null)
            {
                ViewModel = parameter as LoginViewModel;
                ViewModel.PropertyChanged += OnViewModelPropertyChanged;
            }

            return ViewModel != null &&
                !string.IsNullOrEmpty(ViewModel.Login) &&
                !string.IsNullOrEmpty(ViewModel.Password) &&
                ViewModel.Password.Count() > 4;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewModel.Login) ||
                e.PropertyName == nameof(ViewModel.Password))
            {
                OnCanExecuteChanged();
            }
        }

        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                var viewModel = parameter as LoginViewModel;

                var authService = (AuthorizationService)(AppServiceProvider.ServiceProvider.GetService(typeof(AuthorizationService)));
                var user = authService.LoginUser(viewModel.Login, HasherService.HashPassword(viewModel.Password));

                if (user != null)
                {
                    if (user.IsAdmin == true)
                    {
                        var window = (MainView)(AppServiceProvider.ServiceProvider.GetService(typeof(MainView)));
                        (window.DataContext as MainViewModel).UserId = user.Id;
                        window.Show();
                    }
                    else if (user.IsAdmin == false)
                    {
                        var window = (UserMainView)(AppServiceProvider.ServiceProvider.GetService(typeof(UserMainView)));
                        window.ViewModel.UserId = user.Id;
                        window.Show();
                    }

                    viewModel.CloseWindow();
                }
                else
                {
                    MessageBox.Show("User was not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
