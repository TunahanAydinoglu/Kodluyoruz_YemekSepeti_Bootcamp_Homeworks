using FirstApp.Data;
using FirstApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace FirstApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileDatasController : ControllerBase
    {
        FileService fileService = new FileService();

        [HttpGet]
        public List<Product> GetProducts()
        {
            List<Product> myProducts = fileService.Read();
            return myProducts;
        }

        [HttpGet("{id}")]
        public Product GetProductsById(int id)
        {
            List<Product> myProducts = fileService.Read();
            var data = myProducts.FirstOrDefault(c => c.Id == id);
            return data;
        }

        [HttpPost]
        public void PostProduct([FromBody] Product product)
        {
            List<Product> myProducts = fileService.Read();
            myProducts.Add(product);
            fileService.Write(myProducts);
        }

        [HttpPut]
        public Product PutProduct([FromBody] Product product)
        {
            List<Product> myProducts = fileService.Read();

            Product data = myProducts.FirstOrDefault(c => c.Id == product.Id);
            data.Name = product.Name;
            data.Price = product.Price;
            fileService.Write(myProducts);
            return data;
        }

        [HttpDelete("{id}")]
        public void DeleteProductById(int id)
        {
            List<Product> myProducts = fileService.Read();
            Product removeData = myProducts.FirstOrDefault(c => c.Id == id);
            myProducts.Remove(removeData);
            fileService.Write(myProducts);
        }

        [HttpOptions]
        public HttpResponseMessage OptionsProduct()
        {
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }
    }
}
