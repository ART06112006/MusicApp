using Microsoft.EntityFrameworkCore;
using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Repositories.IRepositories
{
    public interface IGetCollectionByQueryRepository<T> where T : class
    {
        public ICollection<T> GetCollectionByQuery(Func<IQueryable<T>, IQueryable<T>> query);
    }
}
