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
    public class SizeProfile:Profile
    {
        public SizeProfile()
        {
            CreateMap<SizeAddDto, Size>();
            CreateMap<SizeUpdateDto, Size>();
            CreateMap<Size, SizeUpdateDto>();
        }
    }
}
