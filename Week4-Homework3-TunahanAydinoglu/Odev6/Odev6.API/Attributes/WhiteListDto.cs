using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev6.API.Attributes
{
    public class WhiteListDto
    {
        public string Ip { get; set; }

        public List<string> Allows { get; set; }

    }
}
