using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Repositories.IRepositories
{
    public interface IGetCollectionByConditionRepository<T> where T : class
    {
        ICollection<T> GetCollectionByCondition(Func<T, bool> predicate);
    }
}
