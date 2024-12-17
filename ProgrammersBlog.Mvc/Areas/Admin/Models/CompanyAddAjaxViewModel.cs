using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class CompanyAddAjaxViewModel
    {
        public CompanyAddDto CompanyAddDto { get; set; }
        public string CompanyAddPartial { get; set; }
        public CompanyDto CompanyDto { get; set; }
    }
}
