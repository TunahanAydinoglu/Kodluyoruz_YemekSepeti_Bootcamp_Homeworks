using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Odev4.API.Data.Context;
using Odev4.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev4.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private AppDbContext _context;

        public SongsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
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
