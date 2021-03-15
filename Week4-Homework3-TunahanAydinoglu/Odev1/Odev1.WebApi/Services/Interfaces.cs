using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev1.WebApi.Services
{
   
        public interface ISingletonService
        {
            DateTime GetCreateDate();
        }
        public interface IScopedService
        {
            DateTime GetCreateDate();
        }
        public interface ITransientService
        {
            DateTime GetCreateDate();
        }
}
