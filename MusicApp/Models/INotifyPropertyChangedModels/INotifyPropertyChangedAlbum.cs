using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MusicApp.Models.INotifyPropertyChangedModels
{
    public class INotifyPropertyChangedAlbum : BaseModel
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

        private Artist _artist;
        public Artist Artist 
        {
            get { return _artist; }
            set
            {
                _artist = value;
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

        private string _genre;
        public string Genre 
        {
            get { return _genre; }
            set
            {
                _genre = value;
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

        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }

        private int _discount;
        public int Discount
        {
            get { return _discount; }
            set
            {
                _discount = value;
                OnPropertyChanged();
            }
        }

        private int _downloadsNumber;
        public int DownloadsNumber
        {
            get { return _downloadsNumber; }
            set
            {
                _downloadsNumber = value;
                OnPropertyChanged();
            }
        }


        public static implicit operator Album(INotifyPropertyChangedAlbum iNotifyPropertyAlbum)
        {
            return new Album
            {
                Id = iNotifyPropertyAlbum.Id,
                Name = iNotifyPropertyAlbum.Name,
                Artist = iNotifyPropertyAlbum.Artist,
                UserId = iNotifyPropertyAlbum.UserId,
                Year = iNotifyPropertyAlbum.Year,
                Genre = iNotifyPropertyAlbum.Genre,
                Photo = iNotifyPropertyAlbum.Photo,
                Price = iNotifyPropertyAlbum.Price,
                Discount = iNotifyPropertyAlbum.Discount,
                DownloadsNumber = iNotifyPropertyAlbum.DownloadsNumber
            };
        }
    }
}
