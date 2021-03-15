using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Odev2.Service.LogService
{
    public class FileService
    {
        private readonly string _filePathRequest = @"Logs/RequestLogs.json";
        private readonly string _filePathResponse = @"Logs/ResponseLogs.json";
        public List<RequestLogDto> ReadRequest()
        {
            return JsonConvert.DeserializeObject<List<RequestLogDto>>(File.ReadAllText(_filePathRequest));
        }
        public List<ResponseLogDto> ReadResponse()
        {
            return JsonConvert.DeserializeObject<List<ResponseLogDto>>(File.ReadAllText(_filePathResponse));
        }
        public void WriteRequest(List<RequestLogDto> model)
        {
            File.WriteAllText(_filePathRequest, JsonConvert.SerializeObject(model));
        }
        public void WriteResponse(List<ResponseLogDto> model)
        {
            File.WriteAllText(_filePathResponse, JsonConvert.SerializeObject(model));
        }
    }
}
