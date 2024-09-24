using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Repositories.IRepositories
{
    public interface IGetAllRepository<T> where T : class
    {
        ICollection<T> GetAll();
    }
}
