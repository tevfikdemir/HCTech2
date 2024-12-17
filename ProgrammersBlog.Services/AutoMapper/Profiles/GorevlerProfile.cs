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
    public class GorevlerProfile:Profile
    {
        public GorevlerProfile()
        {
            CreateMap<GorevlerAddDto, Entities.Concrete.Gorevler>();
            CreateMap<GorevlerUpdateDto, Entities.Concrete.Gorevler>();
            CreateMap<Entities.Concrete.Gorevler, GorevlerUpdateDto>();
        }
    }
}
