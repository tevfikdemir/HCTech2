using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class GorevlerUpdateAjaxViewModel
    {
        public GorevlerUpdateDto GorevlerUpdateDto { get; set; }
        public string GorevlerUpdatePartial { get; set; }
        public GorevlerDto GorevlerDto { get; set; }
    }
}
