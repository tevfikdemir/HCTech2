using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Mvc.Areas.Admin.Models;

namespace ProgrammersBlog.Mvc.AutoMapper.Profiles
{
    public class ViewModelsProfile:Profile
    {
        public ViewModelsProfile()
        {
            CreateMap<ArticleAddViewModel, ArticleAddDto>();
            CreateMap<ArticleUpdateDto, ArticleUpdateViewModel>().ReverseMap();
            CreateMap<ArticleRightSideBarWidgetOptions, ArticleRightSideBarWidgetOptionsViewModel>();
            
            CreateMap<OrderAddViewModel, OrderAddDto>();
            CreateMap<OrderUpdateDto, OrderUpdateViewModel>().ReverseMap();

            CreateMap<PersonWork, PersonPerformansDTO>()
            .ForMember(dest => dest.OperationName, opt => opt.MapFrom(src => src.Operations.OperationName))
            .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.Persons.FirstName)) // Assuming Person has a Name property
            .ForMember(dest => dest.Target, opt => opt.MapFrom(src => src.OrderOperation.OperationTarget))
            .ForMember(dest => dest.OrderType, opt => opt.MapFrom(src => src.Orders.OrderType))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.Performance, opt => opt.MapFrom(src => (double)src.Quantity / src.OrderOperation.OperationTarget * 100));

        }
    }
}
