using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class GorevlerAddAjaxViewModel
    {
        public GorevlerAddDto GorevlerAddDto { get; set; }
        public string GorevlerAddPartial { get; set; }
        public GorevlerDto GorevlerDto { get; set; }
    }
}
