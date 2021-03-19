using AutoMapper;
using Odev8.Data.Entities;
using Odev8.Service.Dtos.Derived;
using Odev8.Service.Dtos.SystemDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Odev8.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RoomEntity, RoomDto>()
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(scr => scr.Rate / 100));


            CreateMap<UserEntity, UserInfo>()
                .ForMember(desc => desc.FullName, opt => opt.MapFrom(scr => string.Concat(scr.Name, scr.SurName)));

        }
    }
}
