using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class OrderAddAjaxViewModel
    {
        public OrderAddDto OrderAddDto { get; set; }
        public string OrderAddPartial { get; set; }
        public OrderDto OrderDto { get; set; }
    }
}
