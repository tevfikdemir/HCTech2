using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    public class Operation : EntityNullBase, IEntity
    {
        public string OperationName { get; set; }
        public string MakinaTipi { get; set; }
        public virtual ICollection<OrderOperation> OrderOperations { get; set; } = new List<OrderOperation>();
        public ICollection<PersonWork> PersonWorks { get; set; } = new List<PersonWork>();

    }
}
