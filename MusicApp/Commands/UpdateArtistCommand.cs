using MusicApp.Exceptions;
using MusicApp.Infrastructure;
using MusicApp.Models;
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
    public class UpdateArtistCommand : BaseCommand
    {
        public UpdateArtistViewModel ViewModel { get; set; }

        public override bool CanExecute(object? parameter)
        {
            if (parameter != null && ViewModel == null)
            {
                ViewModel = parameter as UpdateArtistViewModel;
                ViewModel.PropertyChanged += OnViewModelPropertyChanged;
                ViewModel.Artist.PropertyChanged += OnViewModelPropertyChanged;
            }

            return ViewModel != null &&
                !string.IsNullOrEmpty(ViewModel.Artist.Name) &&
                !string.IsNullOrEmpty(ViewModel.Artist.Country) &&
                ViewModel.Artist.Year > 0 &&
                !string.IsNullOrEmpty(ViewModel.Artist.Photo);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewModel.Artist.Name) ||
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

                var oldAlbum = albumService.GetAlbumById(ViewModel.AlbumId);
                var newAlbum = new Album()
                {
                    Id = oldAlbum.Id,
                    Name = oldAlbum.Name,
                    Year = oldAlbum.Year,
                    Genre = oldAlbum.Genre,
                    Photo = oldAlbum.Photo,
                    UserId = oldAlbum.UserId,
                    Artist = ViewModel.Artist
                };
                albumService.UpdateAlbum(oldAlbum, newAlbum);
            }
            catch (NoChangesException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ItemExistsException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ViewModel.CloseWindow();
        }
    }
}
