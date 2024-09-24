﻿using MusicApp.Commands;
using MusicApp.Commands.UserCommands;
using MusicApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicApp.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        private int? _year;
        public int? Year
        {
            get { return _year; }
            set
            {
                _year = value;
                OnPropertyChanged();
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                if (_userService != null)
                {
                    var user = _userService.GetUserById(_userId);

                    Name = user.Name;
                    Surname = user.Surname;
                    Year = user.Year;
                    Email = user.Email;
                }
            }
        }

        public ICommand ChangeProfileCommand { get; }
        public ICommand TopUpCommand { get; }
        public Action CloseWindow { get; set; }

        private UserService _userService;

        public ProfileViewModel(UserService userService, ChangeProfileCommand userChangeProfileCommand)
        {
            _userService = userService;
            ChangeProfileCommand = userChangeProfileCommand;
        }
    }
}
