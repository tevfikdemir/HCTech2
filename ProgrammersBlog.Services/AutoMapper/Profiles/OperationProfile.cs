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
    public class OperationProfile:Profile
    {
        public OperationProfile()
        {
            CreateMap<OperationAddDto, Operation>();
            CreateMap<OperationUpdateDto, Operation>();
            CreateMap<Operation, OperationUpdateDto>();
        }
    }
}
