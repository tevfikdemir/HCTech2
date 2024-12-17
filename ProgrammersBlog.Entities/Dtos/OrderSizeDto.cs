using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class OrderSizeDto : DtoGetBase
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int SizeId { get; set; }
        public int Quantity { get; set; }
        public int SizeTarget { get; set; }
    }
}
