using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class PersonUpdateAjaxViewModel
    {
        public PersonUpdateDto PersonUpdateDto { get; set; }
        public string PersonUpdatePartial { get; set; }
        public PersonDto PersonDto { get; set; }
    }
}
