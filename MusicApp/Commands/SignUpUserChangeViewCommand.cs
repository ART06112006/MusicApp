using MusicApp.Infrastructure;
using MusicApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Commands
{
    public class SignUpUserChangeViewCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            var window = (SignUpView)(AppServiceProvider.ServiceProvider.GetService(typeof(SignUpView)));
            window.ShowDialog();
        }
    }
}
