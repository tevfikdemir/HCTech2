using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Entities.Dtos
{
    public class PersonAddDto
    {
        [DisplayName("Adı Soyadı")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(70, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")]
        public string FirstName { get; set; }
                 
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public int DepartmentId { get; set; }

        [DisplayName("Kart Numarası")]
        public string PersonCart { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public int GorevlerId { get; set; }

        public bool IsActive { get; set; }
    }
}
