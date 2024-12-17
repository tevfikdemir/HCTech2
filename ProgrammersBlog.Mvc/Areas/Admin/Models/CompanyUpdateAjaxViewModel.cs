using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class CompanyUpdateAjaxViewModel
    {
        public CompanyUpdateDto CompanyUpdateDto { get; set; }
        public string CompanyUpdatePartial { get; set; }
        public CompanyDto CompanyDto { get; set; }
    }
}
