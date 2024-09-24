using MusicApp.Infrastructure;
using MusicApp.Models;
using MusicApp.Models.INotifyPropertyChangedModels;
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
    public class UpdateArtistChangeViewCommand : BaseCommand
    {
        public ShowAlbumViewModel ViewModel { get; set; }

        public override void Execute(object? parameter)
        {
            ViewModel = parameter as ShowAlbumViewModel;

            var window = (UpdateArtistView)(AppServiceProvider.ServiceProvider.GetService(typeof(UpdateArtistView)));
            var artist = ViewModel.Artist;
            window.ViewModel.Artist = new INotifyPropertyChangedArtist()
            {
                Name = artist.Name,
                Country = artist.Country,
                Year = artist.Year,
                Photo = artist.Photo,
            };

            window.ViewModel.AlbumId = artist.Album.Id;

            window.ShowDialog();

            ViewModel.RefreshArtist();
        }
    }
}
