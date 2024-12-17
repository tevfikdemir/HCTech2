using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    public class Size : EntityNullBase, IEntity
    {
        public string SizeName { get; set; }

        public virtual ICollection<OrderSize> OrderSizes { get; set; }

    }
}
