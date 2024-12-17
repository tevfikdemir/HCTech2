using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class SizeAddAjaxViewModel
    {
        public SizeAddDto SizeAddDto { get; set; }
        public string SizeAddPartial { get; set; }
        public SizeDto SizeDto { get; set; }
    }
}
