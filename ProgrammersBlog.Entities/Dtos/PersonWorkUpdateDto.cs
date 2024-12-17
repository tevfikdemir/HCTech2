using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class PersonWorkUpdateDto
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public int OrderId { get; set; }
        public int SizeId { get; set; }
        public int OperationId { get; set; }
        public int OperationCount { get; set; }
        public int TotalQuantity { get; set; }
    }
}
