using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using MusicApp.Context;
using MusicApp.Exceptions;
using MusicApp.Models;
using MusicApp.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Repositories
{
    public class AlbumRepository : IAddRepository<Album>, IUpdateRepository<Album>, IDeleteRepository<Album>, IGetCollectionByConditionRepository<Album>, IGetItemByConditionRepository<Album>, IGetItemByConditionRepository<Artist>, IGetCollectionByConditionRepository<Track>, IGetMaxValueRepository<Album, int>, IGetMaxValueRepository<Album, decimal>, IGetMinValueRepository<Album, decimal>, IGetCollectionByQueryRepository<Album>
    {
        private readonly MusicDbContext _dbContext;
        public AlbumRepository(MusicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Func<IQueryable<Album>, IQueryable<Album>> BuildWhereQuery(Expression<Func<Album, bool>> predicate)
        {
            return query => query.Where(predicate);
        }

        public Func<IQueryable<Album>, IQueryable<Album>> BuildOrderByQuery(Expression<Func<Album, int>> func)
        {
            return query => query.OrderBy(func);
        }

        public Func<IQueryable<Album>, IQueryable<Album>> BuildOrderByDescendingQuery(Expression<Func<Album, int>> func)
        {
            return query => query.OrderByDescending(func);
        }

        public ICollection<Album> GetCollectionByQuery(Func<IQueryable<Album>, IQueryable<Album>> query)
        {
            return query(_dbContext.Albums).ToList();
        }

        public ICollection<Album> GetCollectionByCondition(Func<Album, bool> predicate)
        {
            return _dbContext.Albums.Where(predicate).ToList();
        }

        public Album GetItemByCondition(Func<Album, bool> predicate)
        {
            return _dbContext.Albums.Include(x => x.Tracks).Include(x => x.Artist).Where(predicate).FirstOrDefault();
        }

        public Artist GetItemByCondition(Func<Artist, bool> predicate)
        {
            return _dbContext.Artists.Where(predicate).FirstOrDefault();
        }

        public ICollection<Track> GetCollectionByCondition(Func<Track, bool> predicate)
        {
            return _dbContext.Tracks.Where(predicate).ToList();
        }

        public int GetMaxValue(Func<Album, int> func)
        {
            return _dbContext.Albums.Max(func);
        }

        public decimal GetMaxValue(Func<Album, decimal> func)
        {
            return _dbContext.Albums.Max(func);
        }

        public decimal GetMinValue(Func<Album, decimal> func)
        {
            return _dbContext.Albums.Min(func);
        }

        public void Add(Album item)
        {
            if (_dbContext.Albums.Any(album => album.Name == item.Name &&
                                      album.Artist.Name == item.Artist.Name &&
                                      album.Artist.Country == item.Artist.Country &&
                                      album.Artist.Year == item.Artist.Year &&
                                      album.Artist.Photo == item.Artist.Photo &&
                                      album.Year == item.Year &&
                                      album.Genre == item.Genre &&
                                      album.Photo == item.Photo &&
                                      album.Price == item.Price &&
                                      album.UserId == item.UserId))
            {
                throw new ItemExistsException();
            }
            else
            {
                _dbContext.Albums.Add(item);
                _dbContext.SaveChanges();
            }
        }

        public void Delete(Album item)
        {
            if (!_dbContext.Albums.Any(album => album.Name == item.Name &&
                                      album.Artist.Name == item.Artist.Name &&
                                      album.Artist.Country == item.Artist.Country &&
                                      album.Artist.Year == item.Artist.Year &&
                                      album.Artist.Photo == item.Artist.Photo &&
                                      album.Year == item.Year &&
                                      album.Genre == item.Genre &&
                                      album.Photo == item.Photo &&
                                      album.Price == item.Price &&
                                      album.UserId == item.UserId))
            {
                throw new AlreadyRemovedException();
            }

            _dbContext.Albums.Remove(item);
            _dbContext.SaveChanges();
        }

        public void Update(Album oldItem, Album newItem)
        {
            if (oldItem.Equals(newItem)) throw new NoChangesException();
            
            if (_dbContext.Albums.Any(album => album.Name == newItem.Name &&
                                        album.Artist == newItem.Artist &&
                                        album.Year == newItem.Year &&
                                        album.Genre == newItem.Genre &&
                                        album.Photo == newItem.Photo &&
                                        album.Price == newItem.Price &&
                                        album.Discount == newItem.Discount &&
                                        album.DownloadsNumber == newItem.DownloadsNumber))
            {
                throw new ItemExistsException();
            }

            var oldAlbum = _dbContext.Albums.FirstOrDefault(album => album.Id == oldItem.Id);
            
            if (oldAlbum != null)
            {
                oldAlbum.Name = newItem.Name;
                if (newItem.Artist != null)
                {
                    oldAlbum.Artist.Name = newItem.Artist.Name;
                    oldAlbum.Artist.Country = newItem.Artist.Country;
                    oldAlbum.Artist.Year = newItem.Artist.Year;
                    oldAlbum.Artist.Photo = newItem.Artist.Photo;
                }
                oldAlbum.Year = newItem.Year;
                oldAlbum.Genre = newItem.Genre;
                oldAlbum.Photo = newItem.Photo;
                oldAlbum.Price = newItem.Price;
                oldAlbum.Discount = newItem.Discount;
                oldAlbum.DownloadsNumber = newItem.DownloadsNumber;

                _dbContext.SaveChanges();
            }
        }
    }
}
