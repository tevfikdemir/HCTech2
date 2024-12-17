using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Shared.Entities.Abstract;

namespace ProgrammersBlog.Entities.Concrete 
{
    public class Person:EntityNullBase,IEntity
    {

        public string FirstName { get; set; }
        public int DepartmentId { get; set; }
        public int GorevlerId { get; set; }
        public string PersonCart { get; set; }
        public virtual Gorevler Gorevler { get; set; }
        public virtual Department Department { get; set; }
        public ICollection<PersonWork> PersonWorks { get; set; } = new List<PersonWork>();


    }
}
