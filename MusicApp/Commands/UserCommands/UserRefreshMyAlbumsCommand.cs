using MusicApp.ViewModels;
using MusicApp.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Commands.UserCommands
{
    public class UserRefreshMyAlbumsCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            var viewModel = parameter as UserMainViewModel;
            if (viewModel != null)
            {
                viewModel.RefreshMyAlbums();
            }
        }
    }
}
