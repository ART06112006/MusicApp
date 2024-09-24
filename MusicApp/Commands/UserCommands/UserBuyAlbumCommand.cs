using MusicApp.Exceptions;
using MusicApp.Infrastructure;
using MusicApp.Models;
using MusicApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using MusicApp.ViewModels.UserViewModels;
using System.Transactions;

namespace MusicApp.Commands.UserCommands
{
    public class UserBuyAlbumCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            if (parameter != null)
            {
                var viewModel = parameter as UserBuyAlbumViewModel;

                if (viewModel != null)
                {
                    var albumService = (AlbumService)(AppServiceProvider.ServiceProvider.GetService(typeof(AlbumService)));
                    Album album = albumService.GetAlbumById(viewModel.Album.Id);

                    var userService = (UserService)(AppServiceProvider.ServiceProvider.GetService(typeof(UserService)));

                    var user = userService.GetUserById(viewModel.UserId);

                    var buyAlbumService = (BuyAlbumService)(AppServiceProvider.ServiceProvider.GetService(typeof(BuyAlbumService)));
                    buyAlbumService.ShowTransactionErrorMessage = (string x) => System.Windows.MessageBox.Show(x, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    buyAlbumService.ShowNotEnoughMoneyErrorMessage = () => System.Windows.MessageBox.Show("There is not enough money on the balance!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    buyAlbumService.ShowAlreadyBoughtItemErrorMessage = () => System.Windows.MessageBox.Show("It is a bought album!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    buyAlbumService.ShowSuccessfulTransferMessage = () => System.Windows.MessageBox.Show("The transfer was commited successfully!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

                    buyAlbumService.BuyAlbum(user, album);
                }
            }
        }
    }
}
