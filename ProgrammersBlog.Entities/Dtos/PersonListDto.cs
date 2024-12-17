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
    public class PersonListDto:DtoGetBase
    {
        public IList<Person> Persons{ get; set; }
        public int? DepartmentId { get; set; }
        public int? GorevlerId { get; set; }

    }
}
