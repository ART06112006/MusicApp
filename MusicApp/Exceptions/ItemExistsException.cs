using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Exceptions
{
    public class ItemExistsException : Exception
    {
        public override string Message => "ItemExistsException: item cannot be updated or changed because such an item is already in database!";
        public ItemExistsException() : base() { }
    }
}
