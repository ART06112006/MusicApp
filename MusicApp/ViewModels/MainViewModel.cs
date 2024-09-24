using MusicApp.Commands;
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

namespace MusicApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _searchedAlbum;
        public string SearchedAlbum
        {
            get { return _searchedAlbum; }
            set
            {
                if (_searchedAlbum != value)
                {
                    _searchedAlbum = value;
                    RefreshAlbums(_searchedAlbum);
                    OnPropertyChanged();
                }
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
        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand RefreshCommand { get; }
        public ICommand OpenProfileCommand { get; }

        private readonly AlbumService _albumService;

        private int _userId;
        public int UserId 
        {
            get { return _userId; }
            set
            {
                _userId = value;
                RefreshAlbums();
            }
        }

        public MainViewModel(AlbumService service, ShowAlbumChangeViewCommand showAlbumChangeViewCommand, AddAlbumCommandChangeViewCommand addAlbumCommandChangeViewCommand, RemoveAlbumCommand removeAlbumCommand, RefreshAlbumsCommand refreshAlbumsCommand, ProfileChangeViewCommand profileChangeViewCommand)
        {
            _albumService = service;
            ShowCommand = showAlbumChangeViewCommand;
            AddCommand = addAlbumCommandChangeViewCommand;
            RemoveCommand = removeAlbumCommand;
            RefreshCommand = refreshAlbumsCommand;
            OpenProfileCommand = profileChangeViewCommand;
        }
        
        public void RefreshAlbums()
        {
            Albums = new ObservableCollection<Album>(_albumService.GetAlbumsByUserIdName(UserId));
        }

        public void RefreshAlbums(string name)
        {
            Albums = new ObservableCollection<Album>(_albumService.GetAlbumsByUserIdName(UserId, name));
        }
    }
}
