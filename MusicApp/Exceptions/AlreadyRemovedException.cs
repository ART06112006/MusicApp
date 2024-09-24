using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Exceptions
{
    public class AlreadyRemovedException : Exception
    {
        public override string Message => "AlreadyRemovedException: item was already removed from the database!";
        public AlreadyRemovedException() : base() { }
    }
}
