using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class PersonPerformansListDTO
    {
        public List<PersonPerformansDTO> PersonWorks { get; set; } = new List<PersonPerformansDTO>();
    }
}
