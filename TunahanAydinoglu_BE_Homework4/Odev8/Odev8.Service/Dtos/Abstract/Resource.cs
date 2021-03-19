using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Odev8.Service.Dtos.Abstract
{
    public class Resource
    {
        [JsonProperty(Order = -1)]
        public string Href { get; set; }
    }
}
