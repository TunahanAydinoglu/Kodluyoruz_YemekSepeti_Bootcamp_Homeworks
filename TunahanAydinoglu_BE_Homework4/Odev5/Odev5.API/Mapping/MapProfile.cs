using AutoMapper;
using Odev5.API.Dtos;
using Odev5.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev5.API.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Category, CategoryWithProductsDto>();
            CreateMap<CategoryWithProductsDto, Category>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

        }
    }
}
