using Microsoft.AspNetCore.JsonPatch.Operations;
using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    public class OrderOperation : EntityCrossBase, IEntity 
    {
        public int OperationId { get; set; }
        public int OrderId { get; set; }
        public int OperationTarget { get; set; }
        public int? ConnectOperationId { get; set; } = 0;
        public Operation Operation { get; set; }
        public Order Order { get; set; }
    }
}
