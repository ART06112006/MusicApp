using MusicApp.Infrastructure;
using MusicApp.Models;
using MusicApp.Views;
using MusicApp.Views.UserView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Commands.UserCommands
{
    public class UserShowAlbumChangeViewCommand : BaseCommand
    {
        public int UserId { get; set; }
        public override void Execute(object? parameter)
        {
            if (parameter != null)
            {
                var window = ((UserBuyAlbumView)AppServiceProvider.ServiceProvider.GetService(typeof(UserBuyAlbumView)));
                window.ViewModel.Album = (parameter as Album);
                window.ViewModel.UserId = UserId;
                window.ShowDialog();
            }
        }
    }
}
