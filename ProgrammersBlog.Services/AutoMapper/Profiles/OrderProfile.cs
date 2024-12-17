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
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            // OrderAddDto -> Order
            CreateMap<OrderAddDto, Order>()
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<OrderUpdateDto, Order>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<Order, OrderUpdateDto>();

            CreateMap<Order, OrderDto>();

        }
    }

}
