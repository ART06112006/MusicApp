using MusicApp.Models.INotifyPropertyChangedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }
        public string Photo {  get; set; }
        public Album Album { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Artist artist &&
                artist.Name == Name &&
                artist.Country == Country &&
                artist.Year == Year &&
                artist.Photo == Photo;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Country.GetHashCode() + Year.GetHashCode() + Photo.GetHashCode();
        }

        public static implicit operator INotifyPropertyChangedArtist(Artist iNotifyPropertyArtist)
        {
            return new INotifyPropertyChangedArtist
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
