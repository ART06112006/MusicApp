using MusicApp.Infrastructure;
using MusicApp.ViewModels;
using MusicApp.ViewModels.UserViewModels;
using MusicApp.Views;
using MusicApp.Views.UserView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Commands
{
    public class ProfileChangeViewCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            if (parameter != null)
            {
                var window = ((ProfileView)AppServiceProvider.ServiceProvider.GetService(typeof(ProfileView)));
                window.ViewModel.UserId = (parameter as MainViewModel).UserId;
                window.ShowDialog();
            }
        }
    }
}
