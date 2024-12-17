using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    public class Company : EntityNullBase, IEntity
    {
        public string Name { get; set; }
        public string VergiNo { get; set; }
        public string Phone { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
