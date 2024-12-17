using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Services.AutoMapper.Profiles
{
    public class PersonWorkProfile:Profile
    {
        public PersonWorkProfile()
        {

            CreateMap<PersonWorkAddDto, PersonWork>();
            CreateMap<PersonWorkUpdateDto, PersonWork>();
            CreateMap<PersonWork, PersonWorkUpdateDto>();

            CreateMap<PersonWork, PersonWorkDto>()
            .ForMember(dest => dest.OperationTarget, opt => opt.MapFrom(src => src.OrderOperation.OperationTarget))
    .ReverseMap();
        }
    }
}
