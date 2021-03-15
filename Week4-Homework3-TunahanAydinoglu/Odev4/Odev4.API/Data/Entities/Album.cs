using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev4.API.Data.Entities
{
   
    public class Album
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public int SongCount { get; set; }

    }
}
