using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class OperationAddAjaxViewModel
    {
        public OperationAddDto OperationAddDto { get; set; }
        public string OperationAddPartial { get; set; }
        public OperationDto OperationDto { get; set; }
    }
}
