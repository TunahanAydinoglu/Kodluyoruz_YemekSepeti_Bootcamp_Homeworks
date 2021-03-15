using System;
using System.Collections.Generic;
using System.Text;

namespace Odev8.Service.Dtos.SystemDto
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime ExpireTime { get; set; }
        public string Token { get; set; }
    }
}
