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
    public class AddTrackCommand : BaseCommand
    {
        public AddTrackViewModel ViewModel { get; set; }

        public override bool CanExecute(object? parameter)
        {
            if (parameter != null && ViewModel == null)
            {
                ViewModel = parameter as AddTrackViewModel;
                ViewModel.PropertyChanged += OnViewModelPropertyChanged;
            }

            return ViewModel != null &&
                !string.IsNullOrEmpty(ViewModel.Name) &&
                !string.IsNullOrEmpty(ViewModel.Clip) &&
                !string.IsNullOrEmpty(ViewModel.Preview);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewModel.Name) ||
                e.PropertyName == nameof(ViewModel.Clip) ||
                e.PropertyName == nameof(ViewModel.Preview))
            {
                OnCanExecuteChanged();
            }
        }

        public override void Execute(object? parameter)
        {
            try
            {
                var trackService = (TrackService)(AppServiceProvider.ServiceProvider.GetService(typeof(TrackService)));
                var albumService = (AlbumService)(AppServiceProvider.ServiceProvider.GetService(typeof(AlbumService)));

                var number = albumService.GetAlbumById(ViewModel.AlbumId).Tracks.Count;
                number++;
                var track = new Track() { Name = ViewModel.Name, Clip = ViewModel.Clip, Preview = ViewModel.Preview, Number = number, AlbumId = ViewModel.AlbumId };
                trackService.AddTrack(track);
            }
            catch (ItemExistsException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ViewModel.CloseWindow();
        }
    }
}
