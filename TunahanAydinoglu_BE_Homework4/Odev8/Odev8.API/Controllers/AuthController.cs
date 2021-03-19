using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Odev8.Service.Dtos.SystemDto;
using Odev8.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev8.API.Controllers
{
    [Authorize]
    [Route("/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost(Name = nameof(Authenticate))]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]

        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] TokenRequest req)
        {
            if(req == null)
            {
                return BadRequest();
            }
            var result = await _userService.Authenticate(req);
            if(result == null)
            {
                return Unauthorized();
            }

            return Ok(result);
        }


    }
}
