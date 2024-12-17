using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Entities.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;

namespace ProgrammersBlog.Entities.Dtos
{
    public class PersonWorkDto:DtoGetBase
    {

        public virtual int Id { get; set; }
        public int OrderId { get; set; }
        public int PersonId { get; set; }
        public int SizeId { get; set; }
        public int OperationId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int Quantity { get; set; } = 0;
        public Order Orders { get; set; }
        public Person Persons { get; set; }
        public Size Sizes { get; set; }
        public Operation Operations { get; set; }
        public OrderOperation OrderOperation { get; set; }
        public OrderSize OrderSize{ get; set; }
        public int WorkType { get; set; }

        // Bu kısım eklendi
        public int OrderOperationOrderId { get; set; }
        public int OrderOperationOperationId { get; set; }


         
        public int? OperationTarget { get; set; }
        public int? SizeTarget { get; set; }

        public PersonWork PersonWork { get; set; }
    }
}
