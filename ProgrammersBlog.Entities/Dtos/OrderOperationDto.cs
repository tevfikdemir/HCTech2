using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Entities.Abstract;

namespace ProgrammersBlog.Entities.Dtos
{
    public class OrderOperationDto : DtoGetBase
    {
        public int Id { get; set; }
        public int OperationId { get; set; }
        public int OrderId { get; set; }
        public int OperationTarget { get; set; }
        public int? ConnectOperationId { get; set; } = 0;
        public string Description { get; set; }
        public string OperationName { get; set; }
    }
}
