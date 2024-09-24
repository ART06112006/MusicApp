using MusicApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Commands
{
    public class RefreshAlbumsCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel != null)
            {
                viewModel.RefreshAlbums();
            }
        }
    }
}
