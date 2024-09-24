using Microsoft.EntityFrameworkCore;
using MusicApp.Context;
using MusicApp.Exceptions;
using MusicApp.Models;
using MusicApp.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Repositories
{
    public class TrackRepository : IDeleteRepository<Track>, IAddRepository<Track>
    {
        private readonly MusicDbContext _musicDbContext;
        public TrackRepository(MusicDbContext musicDbContext)
        {
            _musicDbContext = musicDbContext;
        }

        public void Add(Track item)
        {
            if (_musicDbContext.Tracks.Any(track => track.Name == item.Name &&
                                      track.Clip == item.Clip &&
                                      track.Preview == item.Preview))
            {
                throw new ItemExistsException();
            }
            else
            {
                _musicDbContext.Tracks.Add(item);
                _musicDbContext.SaveChanges();
            }
        }

        public void Delete(Track item)
        {
            try
            {
                _musicDbContext.Tracks.Remove(item);
                _musicDbContext.SaveChanges();
                UpdateNumber(item.Album);
            }
            catch (Exception)
            {
                throw new AlreadyRemovedException();
            }
        }

        private void UpdateNumber(Album album)
        {
            var tracks = album.Tracks.ToList();

            for (int i = 0; i < tracks.Count; i++)
            {
                tracks[i].Number = tracks.IndexOf(tracks[i]) + 1;
                _musicDbContext.Entry(tracks[i]).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            _musicDbContext.SaveChanges();
        }
    }
}
