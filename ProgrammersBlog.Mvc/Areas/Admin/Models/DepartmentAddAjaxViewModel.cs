using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class DepartmentAddAjaxViewModel
    {
        public DepartmentAddDto DepartmentAddDto { get; set; }
        public string DepartmentAddPartial { get; set; }
        public DepartmentDto DepartmentDto { get; set; }
    }
}
