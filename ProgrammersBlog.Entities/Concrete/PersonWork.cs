using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    
    public class PersonWork :EntityCrossBase,  IEntity
    {
        public virtual int Id { get; set; }
        public int OrderId { get; set; }
        public int PersonId { get; set; }
        public int OperationId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int Quantity { get; set; } = 0;
        public int WorkType { get; set; }//10 Tamir,20 Makina Tamir,30 Bobin,40 igne, 0 None
        public Order Orders { get; set; }
        public Person Persons { get; set; }
        public Operation Operations { get; set; }   
        public OrderOperation OrderOperation { get; set; }


        // Bu kısım eklendi
        public int OrderOperationOrderId { get; set; }
        public int OrderOperationOperationId { get; set; }
        
    }
}
