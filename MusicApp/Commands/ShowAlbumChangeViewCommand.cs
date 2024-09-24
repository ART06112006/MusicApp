using MusicApp.Infrastructure;
using MusicApp.Models;
using MusicApp.ViewModels;
using MusicApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicApp.Commands
{
    public class ShowAlbumChangeViewCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            if (parameter != null)
            {
                var window = ((ShowAlbumView)AppServiceProvider.ServiceProvider.GetService(typeof(ShowAlbumView)));
                window.ViewModel.Album = (parameter as Album);
                window.ShowDialog();
            }
        }
    }
}
