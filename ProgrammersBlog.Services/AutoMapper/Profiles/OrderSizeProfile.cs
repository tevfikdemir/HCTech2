using AutoMapper;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.AutoMapper.Profiles
{
    public class OrderSizeProfile : Profile
    {
        public OrderSizeProfile()
        {
            CreateMap<OrderSizeAddDto, OrderSize>();
            CreateMap<OrderSizeUpdateDto, OrderSize>();
            CreateMap<OrderSize, OrderSizeUpdateDto>();
            CreateMap<OrderSize, OrderSizeDto>();
        }
    }
}
