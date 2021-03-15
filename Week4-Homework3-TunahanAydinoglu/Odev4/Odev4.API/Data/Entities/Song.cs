using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev4.API.Data.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string Name { get; set; }
    }
}
