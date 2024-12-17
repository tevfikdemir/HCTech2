using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Shared.Entities.Abstract;

namespace ProgrammersBlog.Entities.Concrete
{
    public class Department:EntityNullBase,IEntity
    {
        public string Name { get; set; }
        public ICollection<Person> Persons { get; set; }
    }
}
