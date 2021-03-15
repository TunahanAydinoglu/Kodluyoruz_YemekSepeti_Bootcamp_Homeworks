using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev7.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class RootController : ControllerBase
    {
        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var response = new
            {
                Version1 = new
                {
                    href = "/version?version=1",
                },
                Version2 = new
                {
                    href = "/version?version=2"
                },
                Version3 = new
                {
                    href = "/version?version=3"
                }
            };

            return Ok(response);
        }
    }
}
