using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Models.INotifyPropertyChangedModels
{
    public class INotifyPropertyChangedArtist : BaseModel
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

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

        private string _country;
        public string Country 
        {
            get { return _country; }
            set
            {
                _country = value;
                OnPropertyChanged();
            }
        }

        private int _year;
        public int Year
        {
            get { return _year; }
            set
            {
                _year = value;
                OnPropertyChanged();
            }
        }

        private string _photo;
        public string Photo
        {
            get { return _photo; }
            set
            {
                _photo = value;
                OnPropertyChanged();
            }
        }

        private Album _album; 
        public Album Album 
        {
            get { return _album; }
            set
            {
                _album = value;
                OnPropertyChanged();
            }
        }

        public static implicit operator Artist(INotifyPropertyChangedArtist iNotifyPropertyArtist)
        {
            return new Artist
            {
                Id = iNotifyPropertyArtist.Id,
                Name = iNotifyPropertyArtist.Name,
                Country = iNotifyPropertyArtist.Country,
                Year = iNotifyPropertyArtist.Year,
                Photo = iNotifyPropertyArtist.Photo,
                Album = iNotifyPropertyArtist.Album
            };
        }
    }
}
