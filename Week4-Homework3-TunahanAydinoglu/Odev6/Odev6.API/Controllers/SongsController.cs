using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Odev6.API.Attributes;
using Odev6.API.Data.Context;
using Odev6.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev6.API.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(IpControlAttribute))]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private AppDbContext _context;

        public SongsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = nameof(GetSongs))]
        public IActionResult GetSongs()
        {

            List<Song> songs = _context.Songs.ToList();
            return Ok(songs);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Song song = _context.Songs.FirstOrDefault(song => song.Id == id);
            return Ok(song);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Song song)
        {
            _context.Add(song);
            return Ok();
        }
    }
}
