using MusicApp.Infrastructure;
using MusicApp.Models;
using MusicApp.Views.UserView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Commands.UserCommands
{
    public class UserShowMyAlbumChangeViewCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            if (parameter != null)
            {
                var window = ((UserShowMyAlbumView)AppServiceProvider.ServiceProvider.GetService(typeof(UserShowMyAlbumView)));
                window.ViewModel.Album = (parameter as Album);
                window.ShowDialog();
            }
        }
    }
}
