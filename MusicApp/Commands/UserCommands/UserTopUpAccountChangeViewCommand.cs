using MusicApp.Infrastructure;
using MusicApp.Models;
using MusicApp.ViewModels.UserViewModels;
using MusicApp.Views.UserView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Commands.UserCommands
{
    public class UserTopUpAccountChangeViewCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                var window = ((UserTopUpAccountView)AppServiceProvider.ServiceProvider.GetService(typeof(UserTopUpAccountView)));
                window.ViewModel.UserId = (parameter as UserProfileViewModel).UserId;
                window.ShowDialog();
            }
        }
    }
}
