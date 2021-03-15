using FirstApp.Data;
using FirstApp.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace FirstApp.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly OldSingleton _oldSingleton;
        public ProductsController()
        {
            _oldSingleton = OldSingleton.Instance;
        }

        [HttpGet]
        public List<Product> Get()
        {
            return _oldSingleton.Products;
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var data = _oldSingleton.Products.FirstOrDefault(c => c.Id == id);
            return data;
        }

        [HttpPost]
        public void Post([FromBody] Product product)
        {
            Product newData = new Product { Id = product.Id, Name = product.Name, Price = product.Price };
            _oldSingleton.Products.Add(newData);
        }

        [HttpPut]
        public Product PutProduct([FromBody] Product product)
        {
            Product data = _oldSingleton.Products.FirstOrDefault(c => c.Id == product.Id);
            data.Name = product.Name;
            data.Price = product.Price;
            return data;
        }

        [HttpDelete("{id}")]
        public void DeleteProductById(int id)
        {
            Product removeData = _oldSingleton.Products.FirstOrDefault(c => c.Id == id);
            _oldSingleton.Products.Remove(removeData);
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
