using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Odev2.Service.LogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev2.API.Middlewares
{
    public class RequestResponseLoggerMiddleware
    {

        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger _logger;
        Guid _id;
        private FileService _fileService;
        public RequestResponseLoggerMiddleware(RequestDelegate requestDelegate, ILoggerFactory loggerFactory)
        {
            _requestDelegate = requestDelegate;
            _logger = loggerFactory.CreateLogger<RequestResponseLoggerMiddleware>();
            _fileService = new FileService();
        }


        public async Task Invoke(HttpContext context)
        {
            _id = Guid.NewGuid();
            var request = context.Request;
            RequestMiddleware(request);
            await _requestDelegate(context);
         
            var response = context.Response;
            ResponseMiddleware(response);
        }

        public void RequestMiddleware(HttpRequest request)
        {
            List<RequestLogDto> mylogs = _fileService.ReadRequest();
            RequestLogDto requestLog = new RequestLogDto
            {
                Id = _id,
                Host = request.Host.Value,
                CreatedTime = DateTime.Now,
                Method = request.Method,
                Path = request.Path
            };

            mylogs.Add(requestLog);

            _fileService.WriteRequest(mylogs);
        }

        public void ResponseMiddleware(HttpResponse response)
        {
            List<ResponseLogDto> mylogs = _fileService.ReadResponse();

            ResponseLogDto responseLog = new ResponseLogDto
            {
                Id = _id,
                StatusCode = response.StatusCode,
                CreatedTime = DateTime.Now
            };
            mylogs.Add(responseLog);

            _fileService.WriteResponse(mylogs);

        }

    }
}
