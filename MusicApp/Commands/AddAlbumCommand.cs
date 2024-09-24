using MusicApp.Exceptions;
using MusicApp.Infrastructure;
using MusicApp.Models;
using MusicApp.Models.INotifyPropertyChangedModels;
using MusicApp.Services;
using MusicApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace MusicApp.Commands
{
    public class AddAlbumCommand : BaseCommand
    {
        public AddAlbumViewModel ViewModel { get; set; }

        public override bool CanExecute(object? parameter)
        {
            if (parameter != null && ViewModel == null)
            {
                ViewModel = parameter as AddAlbumViewModel;
                ViewModel.PropertyChanged += OnViewModelPropertyChanged;
                ViewModel.Album.PropertyChanged += OnViewModelPropertyChanged;
                ViewModel.Artist.PropertyChanged += OnViewModelPropertyChanged;
            }

            return (ViewModel != null) &&
                !string.IsNullOrEmpty(ViewModel.Album.Name) &&
                ViewModel.Album.Year > 0 &&
                !string.IsNullOrEmpty(ViewModel.Album.Genre) &&
                !string.IsNullOrEmpty(ViewModel.Album.Photo) &&
                ViewModel.Album.Price >= 0 &&
                HasTwoDecimalPlaces(ViewModel.Album.Price) &&
                ViewModel.Album.Discount >= 0 && ViewModel.Album.Discount <= 100
                &&
                !string.IsNullOrEmpty(ViewModel.Artist.Name) &&
                !string.IsNullOrEmpty(ViewModel.Artist.Country) &&
                ViewModel.Artist.Year != 0 &&
                !string.IsNullOrEmpty(ViewModel.Artist.Photo);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewModel.Album.Name) ||
                e.PropertyName == nameof(ViewModel.Album.Year) ||
                e.PropertyName == nameof(ViewModel.Album.Genre) ||
                e.PropertyName == nameof(ViewModel.Album.Photo) ||
                e.PropertyName == nameof(ViewModel.Album.Price) ||
                e.PropertyName == nameof(ViewModel.Album.Discount) ||
                e.PropertyName == nameof(ViewModel.Artist.Name) ||
                e.PropertyName == nameof(ViewModel.Artist.Country) ||
                e.PropertyName == nameof(ViewModel.Artist.Year) ||
                e.PropertyName == nameof(ViewModel.Artist.Photo))
                {
                    OnCanExecuteChanged();
                }
        }

        public override void Execute(object? parameter)
        {
            try
            {
                var albumService = (AlbumService)(AppServiceProvider.ServiceProvider.GetService(typeof(AlbumService)));

                var album = ViewModel.Album;
                album.Artist = ViewModel.Artist;
                albumService.AddAlbum(album);
            }
            catch (ItemExistsException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ViewModel.CloseWindow();
        }

        private bool HasTwoDecimalPlaces(decimal number)
        {
            int decimalPlaces = BitConverter.GetBytes(decimal.GetBits(number)[3])[2];

            return decimalPlaces == 2 || decimalPlaces == 1 || decimalPlaces == 0;
        }
    }
}
