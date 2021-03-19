using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Odev8.Service.Dtos.Derived;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev8.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {

        private readonly HotelInfoDto _hotelInfoDto;
        public InfoController(IOptions<HotelInfoDto> hotelInfoOptions)
        {
            _hotelInfoDto = hotelInfoOptions.Value;
        }


        [HttpGet(Name = nameof(GetInfo))]
        [ProducesResponseType(200)]
        public ActionResult<HotelInfoDto> GetInfo()
        {
            _hotelInfoDto.Href = Url.Link(nameof(GetInfo), null);
            return _hotelInfoDto;
        }



    }
}
