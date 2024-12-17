using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class OrderUpdateAjaxViewModel
    {
        public OrderUpdateDto OrderUpdateDto { get; set; }
        public string OrderUpdatePartial { get; set; }
        public OrderDto OrderDto { get; set; }
    }
}
