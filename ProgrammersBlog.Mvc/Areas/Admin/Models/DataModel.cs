using Microsoft.VisualBasic;
using System;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class DataModel
    {
        public int OrderId { get; set; }
        public int PersonId { get; set; }
        public int SizeId { get; set; }
        public int OperationId { get; set; }
        public int Quantity { get; set; }
        public int WorkType {  get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

    }
}
