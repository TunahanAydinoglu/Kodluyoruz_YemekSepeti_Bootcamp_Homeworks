using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Odev2.Service.LogService
{
    public class RequestLogDto
    {
        public Guid Id { get; set; }
        public string Method { get; set; }
        public string Host { get; set; }
        public PathString Path { get; set; }
        public DateTime CreatedTime { get; set; }

    }
}
