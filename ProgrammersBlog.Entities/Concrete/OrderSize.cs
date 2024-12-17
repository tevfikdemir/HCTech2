using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    public class OrderSize: EntityCrossBase, IEntity
    {
        public int OrderId { get; set; }
        public int SizeId { get; set; }
        public int SizeTarget { get; set; }
        public Size Size { get; set; }
        public Order Order { get; set; }
    }
}
