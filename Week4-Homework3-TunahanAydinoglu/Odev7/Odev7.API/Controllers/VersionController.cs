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
    [ApiVersion("1", Deprecated = true)]
    [ApiVersion("2")]
    [ApiVersion("3")]
    public class VersionController : ControllerBase
    {

        [HttpGet(Name = nameof(GetVersion1))]
        public IActionResult GetVersion1()
        {
            string version = "Versiyon 1 calisiyor";

            return Ok(version);
        }


        [HttpGet(Name = nameof(GetVersion2))]
        public IActionResult GetVersion2()
        {
            string version = "Versiyon 2 calisiyor";

            return Ok(version);
        }

        [HttpGet(Name = nameof(GetVersion3))]
        public IActionResult GetVersion3()
        {
            string version = "Versiyon 3 calisiyor";

            return Ok(version);
        }

    }
}
