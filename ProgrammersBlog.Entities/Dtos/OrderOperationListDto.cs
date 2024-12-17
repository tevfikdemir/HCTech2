using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Entities.Abstract;

namespace ProgrammersBlog.Entities.Dtos
{
    public class OrderOperationListDto : DtoGetBase
    {
        public IList<OrderOperationDto> OrderOperations { get; set; }
        public IList<OrderSizeDto> OrderSizes { get; set; }

    }
}
