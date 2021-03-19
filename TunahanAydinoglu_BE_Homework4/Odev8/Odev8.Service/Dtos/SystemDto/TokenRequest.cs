using System;
using System.Collections.Generic;
using System.Text;

namespace Odev8.Service.Dtos.SystemDto
{
    public class TokenRequest
    {
        public string LoginUser { get; set; }
        public string LoginPassword { get; set; }
    }
}
