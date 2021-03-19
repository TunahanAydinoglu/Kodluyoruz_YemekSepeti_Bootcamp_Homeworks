using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Odev8.Service.Dtos.SystemDto
{
    public class ApiError
    {
        public string Message { get; set; }
        public string Detail { get; set; }
        public ApiVersion Version { get; set; }
    }
}
