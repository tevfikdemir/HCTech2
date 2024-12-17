using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Entities.Dtos
{
    public class OrderAddDto
    {
        [DisplayName("Sipariş No")]
        [MaxLength(15, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(1, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public string OrderNumber { get; set; }

        [DisplayName("Sipariş Adı")]
        [MaxLength(20, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(1, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public string OrderName { get; set; }

        [DisplayName("Sipariş Tanımı")]
        [MaxLength(30, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(1, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public string OrderType { get; set; }

        [DisplayName("Tarih")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime OrderDate { get; set; }
        public string Thumbnail { get; set; }

        [DisplayName("Adet")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]

        public int OrderQuantity { get; set; }

        [DisplayName("Gunluk Hedef")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public int DayTarget { get; set; }

        [DisplayName("Kesim Oran%")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public int KesimOran { get; set; }
        public int CompanyId { get; set; }
        public DateTime CreatedDate { get; set; }

        public string Description { get; set; }

        [DisplayName("Aktif Mi?")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public bool IsActive { get; set; }
        public List<OrderSize> OrderSizes { get; set; }
        public List<OrderOperation> OrderOperations { get; set; }
    }
}
