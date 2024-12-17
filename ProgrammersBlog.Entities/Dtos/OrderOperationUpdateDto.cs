using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class OrderOperationUpdateDto
    {
        public int Id { get; set; }
        public int OperationId { get; set; }
        public int OrderId { get; set; }
        public int OperationTarget { get; set; }
        public int? ConnectOperationId { get; set; } = 0;
        public string Description { get; set; }
    }
}
