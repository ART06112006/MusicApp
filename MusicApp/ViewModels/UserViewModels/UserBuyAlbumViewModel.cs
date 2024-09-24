using MusicApp.Commands.UserCommands;
using MusicApp.Models;
using MusicApp.Models.INotifyPropertyChangedModels;
using MusicApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicApp.ViewModels.UserViewModels
{
    public class UserBuyAlbumViewModel : BaseViewModel
    {
        private INotifyPropertyChangedAlbum _album;
        public INotifyPropertyChangedAlbum Album
        {
            get { return _album; }
            set
            {
                _album = value;
                RefreshArtist();
                RefreshTracks();
                OnPropertyChanged();
            }
        }

        private INotifyPropertyChangedArtist _artist;
        public INotifyPropertyChangedArtist Artist
        {
            get { return _artist; }
            set
            {
                _artist = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Track> _tracks;
        public ObservableCollection<Track> Tracks
        {
            get { return _tracks; }
            set
            {
                if (_tracks != value)
                {
                    _tracks = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand BuyCommand { get; }
        public ICommand OpenCommand { get; }

        private readonly AlbumService _albumService;

        public int UserId { get; set; }

        public UserBuyAlbumViewModel(AlbumService albumService, UserBuyAlbumCommand userBuyAlbumCommand, OpenPreviewCommand openPreviewCommand)
        {
            _albumService = albumService;
            BuyCommand = userBuyAlbumCommand;
            OpenCommand = openPreviewCommand;
        }

        public void RefreshTracks()
        {
            Tracks = _albumService.GetTracksById(Album.Id);
        }

        public void RefreshArtist()
        {
            Artist = _albumService.GetArtistById(Album.Id);
        }

        public void RefreshAlbum()
        {
            Album = _albumService.GetAlbumById(Album.Id);
        }
    }
}
