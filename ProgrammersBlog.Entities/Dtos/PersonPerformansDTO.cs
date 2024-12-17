using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class PersonPerformansDTO
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string OperationName { get; set; }
        public string PersonName { get; set; }
        public int Target { get; set; }
        public string OrderType { get; set; }
        public int Quantity { get; set; }
        public int OperationTarget { get; set; }
        public double Performance { get; set; }
    }
}
