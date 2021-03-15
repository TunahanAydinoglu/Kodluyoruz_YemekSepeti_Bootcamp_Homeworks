using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev1.WebApi.Services
{
    public class Service : IScopedService,ISingletonService,ITransientService
    {
        private readonly DateTime _createdTime;
        public Service()
        {
            _createdTime = DateTime.Now;
        }
        public DateTime GetCreateDate()
        {
            return _createdTime;
        }
    }
}
