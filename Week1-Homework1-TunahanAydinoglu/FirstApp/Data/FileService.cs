using FirstApp.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace FirstApp.Data
{
    public class FileService
    {
        private readonly string _filePath = @"JSON/Products.json";
        public List<Product> Read()
        {
            return JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(_filePath));
        }
        public void Write(List<Product> model)
        {
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(model));
        }
    }
}
