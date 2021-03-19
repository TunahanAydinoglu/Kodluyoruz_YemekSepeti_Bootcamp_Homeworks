using System;
using System.Collections.Generic;
using System.Text;

namespace Odev2.Service.LogService
{
    public class ResponseLogDto
    {
        public Guid Id { get; set; }
        public int StatusCode { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
