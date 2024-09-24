using MusicApp.Exceptions;
using MusicApp.Models;
using MusicApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Services
{
    public class AuthorizationService
    {
        private readonly UserRepository _userRepository;
        public AuthorizationService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User? LoginUser(string name, string password)
        {
            return _userRepository.GetItemByCondition((User x) => x.Login == name && x.Password == password);
        }

        public bool RegisterUser(User user)
        {
            try
            {
                _userRepository.Add(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
