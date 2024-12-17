using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    public class Order : EntityNullBase, IEntity
    {
        public string OrderNumber { get; set; }
        public string OrderName   { get; set; }
        public string OrderType { get; set; }
        public DateTime OrderDate { get; set; }
        public string Thumbnail { get; set; }
        public int OrderQuantity { get; set; } 
        public int DayTarget { get; set; }
        public int KesimOran { get; set; }
        public int CompanyId { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now; // override CreatedDate = new DateTime(2020/01/01);
        public virtual string CreatedByName { get; set; } = "Admin";
        public ICollection<PersonWork> PersonWorks { get; set; } = new List<PersonWork>();
        public ICollection<OrderSize> OrderSizes { get; set; } = new List<OrderSize>();
        public virtual ICollection<OrderOperation> OrderOperations { get; set; } = new List<OrderOperation>();
        public Company Companies { get; set; }
    }
}
