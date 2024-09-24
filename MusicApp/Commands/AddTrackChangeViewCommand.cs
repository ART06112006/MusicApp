using MusicApp.Infrastructure;
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
    public class AddTrackChangeViewCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            var viewModel = parameter as ShowAlbumViewModel;
            var window = (AddTrackView)(AppServiceProvider.ServiceProvider.GetService(typeof(AddTrackView)));
            (window.DataContext as AddTrackViewModel).AlbumId = viewModel.Album.Id;
            window.ShowDialog();
            viewModel.RefreshTracks();
        }
    }
}
