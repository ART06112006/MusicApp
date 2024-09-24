using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Repositories.IRepositories
{
    public interface IGetMinValueRepository<T, V> where T : class
    {
        V GetMinValue(Func<T, V> func);
    }
}
