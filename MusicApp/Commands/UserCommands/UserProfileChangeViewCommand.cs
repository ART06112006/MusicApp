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
    public class UserProfileChangeViewCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            if (parameter != null)
            {
                var window = ((UserProfileView)AppServiceProvider.ServiceProvider.GetService(typeof(UserProfileView)));
                window.ViewModel.UserId = (parameter as UserMainViewModel).UserId;
                window.ShowDialog();
            }
        }
    }
}
