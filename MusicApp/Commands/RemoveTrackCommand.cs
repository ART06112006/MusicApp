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
    public class RemoveTrackCommand : BaseCommand
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
                        var service = (TrackService)(AppServiceProvider.ServiceProvider.GetService(typeof(TrackService)));
                        service.DeleteTrack(parameter as Track);
                        System.Windows.Forms.MessageBox.Show("Close this window and open it again in order to see the changes!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
