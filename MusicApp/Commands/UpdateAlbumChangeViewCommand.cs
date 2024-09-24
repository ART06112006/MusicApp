using MusicApp.Infrastructure;
using MusicApp.Models.INotifyPropertyChangedModels;
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
    public class UpdateAlbumChangeViewCommand : BaseCommand
    {
        public ShowAlbumViewModel ViewModel { get; set; }

        public override void Execute(object? parameter)
        {
            ViewModel = parameter as ShowAlbumViewModel;

            var window = (UpdateAlbumView)(AppServiceProvider.ServiceProvider.GetService(typeof(UpdateAlbumView)));
            var album = ViewModel.Album;
            window.ViewModel.Album = new INotifyPropertyChangedAlbum()
            {
                Id = album.Id,
                Name = album.Name,
                Year = album.Year,
                Genre = album.Genre,
                Photo = album.Photo,
                Price = album.Price,
                Discount = album.Discount,
                DownloadsNumber = album.DownloadsNumber,
                Artist = album.Artist
            };

            window.ShowDialog();

            ViewModel.RefreshAlbum();
        }
    }
}
