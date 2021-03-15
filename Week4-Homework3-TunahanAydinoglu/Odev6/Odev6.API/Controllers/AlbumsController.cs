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
    public class AlbumsController : ControllerBase
    {
        private AppDbContext _context;
        public AlbumsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = nameof(GetAlbums))]
        public IActionResult GetAlbums()
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
