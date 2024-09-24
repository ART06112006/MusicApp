using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Repositories.IRepositories
{
    public interface IGetMaxValueRepository<T, V> where T : class
    {
        V GetMaxValue(Func<T, V> func);
    }
}
