using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Odev1.WebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LifeCyclesController : ControllerBase
    {
        private readonly ISingletonService _singletonService1;
        private readonly ISingletonService _singletonService2;
        private readonly IScopedService _scopedService1;
        private readonly IScopedService _scopedService2;
        private readonly ITransientService _transientService1;
        private readonly ITransientService _transientService2;


        public LifeCyclesController(
            ITransientService transientService1,
                                         ITransientService transientService2,
                                         IScopedService scopedService1,
                                         IScopedService scopedService2,
                                         ISingletonService singletonService1,
                                         ISingletonService singletonService2
            )
        {
            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;
            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;
            _transientService1 = transientService1;
            _transientService2 = transientService2;
        }


        [HttpGet]
        public string Get()
        {
            string result = 
                            $"Singleton1 create Date : {_singletonService1.GetCreateDate() } {Environment.NewLine}" +
                            $"singleton2 create Date : {_singletonService2.GetCreateDate()} {Environment.NewLine}"+
                            $"Scoped1 create Date : {_scopedService1.GetCreateDate() } {Environment.NewLine}" +
                            $"Scoped2 create Date : {_scopedService2.GetCreateDate()} {Environment.NewLine}" +
                            $"Transient1 create Date : {_transientService1.GetCreateDate()} {Environment.NewLine}" +
                            $"Transient2 create Date : {_transientService2.GetCreateDate()} {Environment.NewLine}" +
                            "Refresh and check Date";

            return result;



        }

    }
}
