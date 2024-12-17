using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class OrderAddViewModel
    {
        

        [DisplayName("Sipariş No")]
        [MaxLength(15, ErrorMessage = "< {1}")]
        [MinLength(1, ErrorMessage = "> {1}")]
        [Required(ErrorMessage = "*")]
        public string OrderNumber { get; set; }

        [DisplayName("Sipariş Adı")]
        [MaxLength(20, ErrorMessage = "< {1}")]
        [MinLength(1, ErrorMessage = "> {1}")]
        [Required(ErrorMessage = "*")]
        public string OrderName { get; set; }

        [DisplayName("Sipariş Tanımı")]
        [MaxLength(30, ErrorMessage = "< {1}")]
        [MinLength(1, ErrorMessage = "> {1}")]
        [Required(ErrorMessage = "*")]
        public string OrderType { get; set; }

        [DisplayName("Tarih")]
        //[Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string Thumbnail { get; set; } = "Resim";

        [DisplayName("Adet")]
        [Required(ErrorMessage = "*")]
        public int OrderQuantity { get; set; }

        [DisplayName("Gunluk Hedef")]
        [Required(ErrorMessage = "*")]
        [Range(10, int.MaxValue, ErrorMessage = ">10 *")]
        public int DayTarget { get; set; }

        [DisplayName("Kesim Oranı %")]
        [Required(ErrorMessage = "*")]
        public int KesimOran { get; set; }

        [DisplayName("Firma")]
        [Required(ErrorMessage = "*")]
        public int? CompanyId { get; set; }

        [DisplayName("Aktif Mi?")]
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Description { get; set; }
        public string CreatedByName { get; set; } = "Admin";

        
        public int? SizeId { get; set; }
        public int? SizeTarget { get; set; }

        public int? ConnectOperationId { get; set; }

        [DisplayName("Operasyon")]
        public int? OperationId { get; set; }
        public int? OperationTarget { get; set; }
        
        
        public IList<Size> Sizes { get; set; }
        public IList<Operation> Operations { get; set; }
        public IList<Company> Companies { get; set; }
        public List<OrderSize> OrderSizes { get; set; }
        public List<OrderOperation> OrderOperations { get; set; }
    }
}
