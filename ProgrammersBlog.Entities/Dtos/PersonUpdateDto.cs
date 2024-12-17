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
    public class PersonUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("Adı Soyadı")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string FirstName { get; set; }
        
         
        [DisplayName("Departman")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public int DepartmentId { get; set; }

        [DisplayName("Kart Numarası")]
        public string PersonCart { get; set; }
        public IList<Department> Departments { get; set; }
        public Department Department { get; set; }

        [DisplayName("Aktif Mi?")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public bool IsActive { get; set; }
        [DisplayName("Silinsin Mi?")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public bool IsDeleted { get; set; }
       
    }
}
