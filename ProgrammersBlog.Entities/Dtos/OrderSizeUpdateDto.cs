using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class OrderSizeUpdateDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int SizeId { get; set; }
        public int SizeTarget { get; set; }
    }
}
