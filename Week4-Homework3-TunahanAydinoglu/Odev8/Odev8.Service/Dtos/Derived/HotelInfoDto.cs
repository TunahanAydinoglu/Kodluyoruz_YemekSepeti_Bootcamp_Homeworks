using Odev8.Service.Dtos.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Odev8.Service.Dtos.Derived
{
    public class HotelInfoDto : Resource
    {
        public string Title { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public HotelAddressDto Location { get; set; }
    }
}
