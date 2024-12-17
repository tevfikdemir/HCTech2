using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class SizeUpdateAjaxViewModel
    {
        public SizeUpdateDto SizeUpdateDto { get; set; }
        public string SizeUpdatePartial { get; set; }
        public SizeDto SizeDto { get; set; }
    }
}
