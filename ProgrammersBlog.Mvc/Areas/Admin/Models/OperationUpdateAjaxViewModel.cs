using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class OperationUpdateAjaxViewModel
    {
        public OperationUpdateDto OperationUpdateDto { get; set; }
        public string OperationUpdatePartial { get; set; }
        public OperationDto OperationDto { get; set; }
    }
}
