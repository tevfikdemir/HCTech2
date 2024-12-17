using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class DepartmentUpdateAjaxViewModel
    {
        public DepartmentUpdateDto DepartmentUpdateDto { get; set; }
        public string DepartmentUpdatePartial { get; set; }
        public DepartmentDto DepartmentDto { get; set; }
    }
}
