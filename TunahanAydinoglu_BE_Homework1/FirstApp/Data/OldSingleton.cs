using FirstApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp.Data
{
    public class OldSingleton
    {
        private static volatile OldSingleton _instance = null;
        private static readonly object padLock = new object();
        public List<Product> Products = new List<Product>();

        public static OldSingleton Instance
        {
            get
            {
                lock (padLock)
                {
                    if (_instance == null)
                    {
                        _instance = new OldSingleton();
                    }
                }
                return _instance;
            }
        }

        private OldSingleton()
        {
            GetData();
        }

        private void GetData()
        {
            for (int index = 1; index <= 10; index++)
            {
                Product newProduct = new Product { Id = index, Name = "ProductName - " + index, Price = 50 + (index * 3) };
                Products.Add(newProduct);
            }
        }


    }
}
