using MusicApp.Infrastructure;
using MusicApp.Services;
using MusicApp.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicApp.Commands.UserCommands
{
    public class UserTopUpAccountCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                try
                {
                    var viewModel = parameter as UserTopUpAccountViewModel;

                    var userService = (UserService)(AppServiceProvider.ServiceProvider.GetService(typeof(UserService)));

                    var user = userService.GetUserById(viewModel.UserId);

                    user.Balance += viewModel.Amount;

                    userService.UpdateUser(user);
                    MessageBox.Show("Transfer was commited successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transfer was not commited successfully!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
