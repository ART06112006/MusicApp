using Microsoft.EntityFrameworkCore;
using MusicApp.Models;
using MusicApp.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Services
{
    public class AlbumService
    {
        private AlbumRepository _repository;
        public AlbumService (AlbumRepository repository)
        {
            _repository = repository;
        }

        public ObservableCollection<Album> GetAlbumsByName(string name)
        {
            return new ObservableCollection<Album>(_repository.GetCollectionByCondition((Album x) => x.Name.Contains(name) || x.Artist.Name.Contains(name)));
        }

        public ObservableCollection<Album> GetFilteredAlbums(string name, bool? news, int popularityLevel, bool? populars, decimal minPrice, decimal maxPrice)
        {
            //Popularity filter
            var popularityValidateValue = ComputePopularityValidateValue(popularityLevel);

            //Build query
            var query = BuildQuery(name, news, popularityValidateValue, populars, minPrice, maxPrice);

            return new ObservableCollection<Album>(_repository.GetCollectionByQuery(query));
        }

        private double ComputePopularityValidateValue(int popularityLevel)
        {
            var maxDownloadsNumber = _repository.GetMaxValue((Album x) => x.DownloadsNumber);
            var dispersionCoefficient = 0.1;
            var popularityValidateValue = (maxDownloadsNumber * (double)popularityLevel / 5) * (1 - dispersionCoefficient);

            return popularityValidateValue;
        }

        private Func<IQueryable<Album>, IQueryable<Album>> BuildQuery(string name, bool? news, double popularityValidateValue, bool? populars, decimal minPrice, decimal maxPrice)
        {
            Func<IQueryable<Album>, IQueryable<Album>> query;

            //Where
            query = _repository.BuildWhereQuery(x => x.User.IsAdmin == true);

            if (string.IsNullOrEmpty(name))
            {
                var whereQuery = _repository.BuildWhereQuery(x => x.DownloadsNumber >= popularityValidateValue &&
                                                         x.Price >= minPrice && x.Price <= maxPrice);
                query = Compose(whereQuery, query);
            }
            else
            {
                var whereQuery = _repository.BuildWhereQuery(x => (x.Name.Contains(name) || x.Artist.Name.Contains(name)) &&
                                                         x.DownloadsNumber >= popularityValidateValue &&
                                                         x.Price >= minPrice && x.Price <= maxPrice);
                query = Compose(whereQuery, query);
            }

            //OrderBy
            if (news == true)
            {
                var orderByDescending = _repository.BuildOrderByDescendingQuery(x => x.Id);
                query = Compose(orderByDescending, query);
            }
            else if (news == false)
            {
                var orderBy = _repository.BuildOrderByQuery(x => x.Id);
                query = Compose(orderBy, query);
            }

            if (populars == true)
            {
                var orderByDescending = _repository.BuildOrderByDescendingQuery(x => x.DownloadsNumber);
                query = Compose(orderByDescending, query);
            }
            else if (populars == false)
            {
                var orderBy = _repository.BuildOrderByQuery(x => x.DownloadsNumber);
                query = Compose(orderBy, query);
            }

            return query;
        }

        private Func<T, TResult> Compose<T, TIntermediate, TResult>(Func<T, TIntermediate> inner, Func<TIntermediate, TResult> outer)
        {
            return arg => outer(inner(arg));
        }

        public ObservableCollection<Album> GetAlbumsByUserIdName(int userId, string name = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new ObservableCollection<Album>(_repository.GetCollectionByCondition((Album x) => x.UserId == userId));
            }
            else
            {
                return new ObservableCollection<Album>(_repository.GetCollectionByCondition((Album x) => x.UserId == userId && x.Name.Contains(name)));
            }
        }

        public Album GetAlbumById(int id)
        {
            return _repository.GetItemByCondition((Album x) => x.Id == id);
        }

        public Artist GetArtistById(int id)
        {
            return _repository.GetItemByCondition((Artist x) => x.Id == id);
        }
        
        public ObservableCollection<Track> GetTracksById(int id)
        {
            return new ObservableCollection<Track>(_repository.GetCollectionByCondition((Track x) => x.AlbumId == id));
        }

        public decimal GetMaxPrice()
        {
            return _repository.GetMaxValue((Album x) => x.Price);
        }

        public decimal GetMinPrice()
        {
            return _repository.GetMinValue((Album x) => x.Price);
        }

        public void AddAlbum(Album album)
        {
            _repository.Add(album);
        }

        public void DeleteAlbum(Album album)
        {
            _repository.Delete(album);
        }

        public void UpdateAlbum(Album oldAlbum, Album newAlbum)
        {
            _repository.Update(oldAlbum, newAlbum);
        }
    }
}
