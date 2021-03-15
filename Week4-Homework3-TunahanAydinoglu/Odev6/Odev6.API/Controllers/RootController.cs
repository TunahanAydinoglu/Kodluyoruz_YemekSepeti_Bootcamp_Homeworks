using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Odev6.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev6.API.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(IpControlAttribute))]
    [ApiController]
    public class RootController : ControllerBase
    {
        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var response = new
            {
                WhiteList = new
                {
                    Ip = "::1",
                    Allows = new
                    {
                        AlbumsController = "/api/albums",
                        RootController = "/api/root"
                    }
                },
                href = Url.Link(nameof(GetRoot), null),
                Albums = new
                {
                    href = Url.Link(nameof(AlbumsController.GetAlbums), null)
                },
                Songs = new
                {
                    href = Url.Link(nameof(SongsController.GetSongs), null)
                },
            };

            return Ok(response);
        }
    }
}
