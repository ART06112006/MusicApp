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
    public class AddAlbumCommandChangeViewCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            var viewModel = parameter as MainViewModel;

            var window = ((AddAlbumView)AppServiceProvider.ServiceProvider.GetService(typeof(AddAlbumView)));
            (window.DataContext as AddAlbumViewModel).Album.UserId = viewModel.UserId;
            window.ShowDialog();

            viewModel.RefreshAlbums();
        }
    }
}
