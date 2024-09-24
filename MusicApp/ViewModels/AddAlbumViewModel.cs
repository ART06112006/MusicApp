using MusicApp.Commands;
using MusicApp.Models;
using MusicApp.Models.INotifyPropertyChangedModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicApp.ViewModels
{
    public class AddAlbumViewModel : BaseViewModel
    {
        private INotifyPropertyChangedAlbum _album;
        public INotifyPropertyChangedAlbum Album
        {
            get { return _album; }
            set
            {
                _album = value;
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

        public ICommand AddCommand { get; }
        public Action CloseWindow { get; set; }

        public AddAlbumViewModel(AddAlbumCommand addAlbumCommand) 
        {
            Album = new INotifyPropertyChangedAlbum();
            Artist = new INotifyPropertyChangedArtist();
            AddCommand = addAlbumCommand;
        }
    }
}
