using Microsoft.AspNetCore.Mvc;
using Odev4.API.Data.Context;
using Odev4.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Odev4.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private AppDbContext _context;
        public AlbumsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {

            List<Album> albums = _context.Albums.ToList();
            return Ok(albums);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Album album = _context.Albums.FirstOrDefault(album => album.Id == id);
            return Ok(album);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Album album)
        {
            _context.Add(album);
            return Ok();
        }

    }
}
