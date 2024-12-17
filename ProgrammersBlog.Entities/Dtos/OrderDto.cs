using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class OrderDto : DtoGetBase
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string OrderName { get; set; }
        public string OrderType { get; set; }
        public DateTime OrderDate { get; set; }
        public string Thumbnail { get; set; }
        public int OrderQuantity { get; set; }
        public int DayTarget { get; set; }
        public int KesimOran { get; set; }
        public string Description { get; set; }

        public List<OrderSize> OrderSizes { get; set; }
        public List<OrderOperation> OrderOperations { get; set; }

    }
}
