using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class PersonAddAjaxViewModel
    {
        public PersonAddDto PersonAddDto { get; set; }
        public string PersonAddPartial { get; set; }
        public PersonDto PersonDto { get; set; }
    }
}
