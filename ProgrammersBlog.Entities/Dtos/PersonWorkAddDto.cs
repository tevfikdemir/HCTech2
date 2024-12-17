using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class PersonWorkAddDto
    {
        public int OrderId { get; set; }
        public int PersonId { get; set; }
        public int SizeId { get; set; }
        public int OperationId { get; set; }
        public int Quantity { get; set; } = 0;
        public int WorkType { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public Order Orders{ get; set; }
        public Person Persons { get; set; }
        public Size Sizes { get; set; }
        public Operation Operations { get; set; }
        public int OrderOperationOrderId { get; set; }
        public int OrderOperationOperationId { get; set; }

        public int OrderSizeOrderId { get; set; }
        public int OrderSizeSizeId { get; set; }
    }
}
