using Odev8.Service.Dtos.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Odev8.Service.Dtos.Derived
{
    public class RoomDto : Resource
    {
        public string Name { get; set; }
        public int Rate { get; set; }
    }
}
