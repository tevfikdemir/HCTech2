using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Entities.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;

namespace ProgrammersBlog.Entities.Dtos
{
    public class PersonWorkListDto:DtoGetBase
    {
        public IList<PersonWorkDto> PersonWorks { get; set; }
        public int OrderId { get; set; }
        public int PersonId { get; set; }
        public int SizeId { get; set; }
        public int OperationId { get; set; }

        public int Quantity { get; set; } = 0;

        public DateTime CreateDate { get; set; }

    }
}
