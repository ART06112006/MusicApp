using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Repositories.IRepositories
{
    public interface IGetItemByConditionRepository<T> where T : class
    {
        T GetItemByCondition(Func<T, bool> predicate);
    }
}
