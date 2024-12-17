using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.AutoMapper.Profiles;

namespace ProgrammersBlog.Services.AutoMapper.Profiles
{
    public class OrderOperationProfile:Profile
    {
        public OrderOperationProfile()
        {
            CreateMap<OrderOperation, OrderOperationDto>();
            CreateMap<OrderOperationAddDto, OrderOperation>();
            CreateMap<OrderOperationUpdateDto, OrderOperation>();
            CreateMap<OrderOperation, OrderOperationUpdateDto>();
        }
    }
}
 