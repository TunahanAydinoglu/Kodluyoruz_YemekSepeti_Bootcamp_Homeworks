using AutoMapper;
using Odev5.Core.Entities;
using Odev5.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Odev5.Service.Mapping
{
    public class MapProfile : Profile
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
