using MusicApp.Models;
using MusicApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetItemByCondition(x => x.Id == id);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }
    }
}
