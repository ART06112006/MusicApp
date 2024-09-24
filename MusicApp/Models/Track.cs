using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Clip { get; set; }
        public string Preview { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
