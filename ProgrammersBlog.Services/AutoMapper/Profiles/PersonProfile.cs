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
    public class PersonProfile:Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonAddDto, Person>();
            CreateMap<PersonUpdateDto, Person>();
            CreateMap<Person, PersonUpdateDto>();
            
        }
    }
}
