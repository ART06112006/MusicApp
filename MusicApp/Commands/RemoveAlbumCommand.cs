using MusicApp.Exceptions;
using MusicApp.Infrastructure;
using MusicApp.Models;
using MusicApp.Services;
using MusicApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace MusicApp.Commands
{
    public class RemoveAlbumCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            if (parameter != null)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Do you really want to remove the album?", "Warning!", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                if (result == MessageBoxResult.OK)
                {
                    try
                    {
                        var service = (AlbumService)(AppServiceProvider.ServiceProvider.GetService(typeof(AlbumService)));
                        service.DeleteAlbum(parameter as Album);
                    }
                    catch (AlreadyRemovedException ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
