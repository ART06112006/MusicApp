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
    public class UserRepository : IAddRepository<User>, IGetItemByConditionRepository<User>
    {
        private readonly MusicDbContext _dbContext;
        public UserRepository(MusicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(User item)
        {
            if (_dbContext.Users.Any(user => user.Login == item.Login &&
                                      user.Email == item.Email))
            {
                throw new ItemExistsException();
            }
            else
            {
                _dbContext.Users.Add(item);
                _dbContext.SaveChanges();
            }
        }

        public void Add(User user, Album album)
        {
            user.Albums.Add(album);
            _dbContext.SaveChanges();
        }

        public void Update(User user)
        {
            _dbContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public User GetItemByCondition(Func<User, bool> predicate)
        {
            return _dbContext.Users.Include(x => x.Albums).Where(predicate).FirstOrDefault();
        }
    }
}
