using MusicApp.Commands;
using MusicApp.Commands.UserCommands;
using MusicApp.Models;
using MusicApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace MusicApp.ViewModels.UserViewModels
{
    public class UserMainViewModel : BaseViewModel
    {
        /////// Shop Albums Tab ///////
        
        private string _searchedAlbum;
        public string SearchedAlbum
        {
            get { return _searchedAlbum; }
            set
            {
                if (_searchedAlbum != value)
                {
                    _searchedAlbum = value;
                    RefreshAlbums(_searchedAlbum, _newContent, _popularity, _popularContent, _selectedMinPrice, _selectedMaxPrice);
                    OnPropertyChanged();
                }
            }
        }

        private bool? _newContent;
        public bool? NewContent
        {
            get { return _newContent; }
            set
            {
                if (_newContent != value)
                {
                    _newContent = value;
                    RefreshAlbums(_searchedAlbum, _newContent, _popularity, _popularContent, _selectedMinPrice, _selectedMaxPrice);
                }
            }
        }

        private int _popularity;
        public int Popularity
        {
            get { return _popularity; }
            set
            {
                if (_popularity != value)
                {
                    _popularity = value;
                    RefreshAlbums(_searchedAlbum, _newContent, _popularity, _popularContent, _selectedMinPrice, _selectedMaxPrice);
                    OnPropertyChanged();
                }
            }
        }

        private bool? _popularContent;
        public bool? PopularContent
        {
            get { return _popularContent; }
            set
            {
                if (_popularContent != value)
                {
                    _popularContent = value;
                    RefreshAlbums(_searchedAlbum, _newContent, _popularity, _popularContent, _selectedMinPrice, _selectedMaxPrice);
                }
            }
        }

        private decimal _minimalPrice;
        public decimal MinimalPrice
        {
            get { return _minimalPrice; }
            set
            {
                _minimalPrice = value;
                OnPropertyChanged();
            }
        }

        private decimal _maximalPrice;
        public decimal MaximalPrice
        {
            get { return _maximalPrice; }
            set
            {
                _maximalPrice = value;
                OnPropertyChanged();
            }
        }

        private decimal _selectedMinPrice;
        public decimal SelectedMinPrice
        {
            get { return _selectedMinPrice; }
            set
            {
                _selectedMinPrice = Math.Round(value, 2);
                RefreshAlbums(_searchedAlbum, _newContent, _popularity, _popularContent, _selectedMinPrice, _selectedMaxPrice);
                OnPropertyChanged();
            }
        }

        private decimal _selectedMaxPrice;
        public decimal SelectedMaxPrice
        {
            get { return _selectedMaxPrice; }
            set
            {
                _selectedMaxPrice = Math.Round(value, 2);
                RefreshAlbums(_searchedAlbum, _newContent, _popularity, _popularContent, _selectedMinPrice, _selectedMaxPrice);
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Album> _albums;
        public ObservableCollection<Album> Albums
        {
            get { return _albums; }
            set
            {
                if (_albums != value)
                {
                    _albums = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ShowCommand { get; }

        /////// My Albums Tab ///////

        private string _searchedMyAlbum;
        public string SearchedMyAlbum
        {
            get { return _searchedMyAlbum; }
            set
            {
                if (_searchedMyAlbum != value)
                {
                    _searchedMyAlbum = value;
                    RefreshMyAlbums(_searchedMyAlbum);
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<Album> _myAlbums;
        public ObservableCollection<Album> MyAlbums
        {
            get { return _myAlbums; }
            set
            {
                if (_myAlbums != value)
                {
                    _myAlbums = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ShowMyCommand { get; }
        public ICommand RemoveMyCommand { get; }
        public ICommand RefreshMyCommand { get; }
        public ICommand OpenProfileCommand { get; }

        //////////////////////////////

        private readonly AlbumService _albumService;

        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                (ShowCommand as UserShowAlbumChangeViewCommand).UserId = _userId;
            }
        }

        public UserMainViewModel(AlbumService albumService, UserShowAlbumChangeViewCommand userShowAlbumChangeViewCommand, UserShowMyAlbumChangeViewCommand userShowMyAlbumChangeViewCommand, UserRemoveMyAlbumCommand userRemoveMyAlbumCommand, UserRefreshMyAlbumsCommand userRefreshMyAlbumsCommand, UserProfileChangeViewCommand userProfileChangeViewCommand)
        {
            _albumService = albumService;
            ShowCommand = userShowAlbumChangeViewCommand;
            ShowMyCommand = userShowMyAlbumChangeViewCommand;
            RemoveMyCommand = userRemoveMyAlbumCommand;
            RefreshMyCommand = userRefreshMyAlbumsCommand;
            OpenProfileCommand = userProfileChangeViewCommand;
            MinimalPrice = _albumService.GetMaxPrice();
            MaximalPrice = _albumService.GetMaxPrice();
            SelectedMaxPrice = MaximalPrice;
            RefreshAlbums(_searchedAlbum, _newContent, _popularity, _popularContent, _selectedMinPrice, _selectedMaxPrice);
        }

        public void RefreshAlbums(string name = "", bool? news = null, int popularityLevel = 0, bool? populars = null, decimal minPrice = 0, decimal maxPrice = 0)
        {
            Albums = _albumService.GetFilteredAlbums(name, news, popularityLevel, populars, minPrice, maxPrice);
        }

        public void RefreshMyAlbums(string name = "")
        {
            MyAlbums = new ObservableCollection<Album>(_albumService.GetAlbumsByUserIdName(UserId, name));
        }
    }
}
