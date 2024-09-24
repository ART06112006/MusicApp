using MusicApp.Commands.UserCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicApp.ViewModels.UserViewModels
{
    public class UserTopUpAccountViewModel : BaseViewModel
    {
        private decimal _amount;
        public decimal Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged();
            }
        }

        public ICommand TopUpCommand { get; }

        public int UserId { get; set; }

        public UserTopUpAccountViewModel(UserTopUpAccountCommand userTopUpAccountCommand)
        {
            TopUpCommand = userTopUpAccountCommand;
        }
    }
}
