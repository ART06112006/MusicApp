using MusicApp.Models.INotifyPropertyChangedModels;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace MusicApp.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Artist Artist { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Photo { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int DownloadsNumber { get; set; }
        public ICollection<Models.Track> Tracks { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Album album = (Album)obj;
            return album.Name == Name &&
                   album.Year == Year &&
                   album.Genre == Genre &&
                   album.Photo == Photo &&
                   album.Price == Price &&
                   album.Discount == Discount &&
                   album.DownloadsNumber == DownloadsNumber &&
                   (album.Artist == null && Artist == null || album.Artist != null && album.Artist.Equals(Artist));
        }

        public static implicit operator INotifyPropertyChangedAlbum(Album iNotifyPropertyAlbum)
        {
            return new INotifyPropertyChangedAlbum
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
