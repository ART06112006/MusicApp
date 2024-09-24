using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Exceptions
{
    public class NoChangesException : Exception
    {
        public override string Message => "NoChangesException: item will not be updated because no changes were made!";
        public NoChangesException() : base() { }
    }
}
