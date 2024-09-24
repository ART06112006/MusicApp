﻿using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicApp.Commands.UserCommands
{
    public class OpenPreviewCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                var track = parameter as Track;
                OpenUrlInBrowser(track.Preview);
            }
        }

        private void OpenUrlInBrowser(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
