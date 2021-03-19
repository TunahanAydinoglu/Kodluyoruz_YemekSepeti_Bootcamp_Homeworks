using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Odev8.Service.Dtos.SystemDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Odev8.Service.Filters
{
    public class JsonExceptionFilters : IExceptionFilter
    {
        private readonly IWebHostEnvironment _env;

        public JsonExceptionFilters(IWebHostEnvironment env)
        {
            _env = env;
        }


        public void OnException(ExceptionContext context)
        {
            var isDevelopment = _env.IsDevelopment();

            var error = new ApiError
            {
                Version = context.HttpContext.GetRequestedApiVersion(),
                Message = isDevelopment ? context.Exception.Message : "Api Error",
                Detail = isDevelopment ? context.Exception.StackTrace : context.Exception.Message
            };

            context.Result = new ObjectResult(error) { StatusCode = 500 };
        }



    }
}
