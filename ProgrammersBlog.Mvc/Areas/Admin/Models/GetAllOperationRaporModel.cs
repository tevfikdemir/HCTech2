using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class GetAllOperationRaporModel
    {
        public int PersonelId { get; set; }
        public string PersonelName { get; set; }
        public int OperationId { get; set; }
        public string OperasyonName { get; set; }
        public int SizeId { get; set; }
        public int OrderId { get; set; }
        public int TotalQuantity { get; set; }
        public Operation Operations { get; set; }
        public Order Orders { get; set; }
        public Size Sizes { get; set; }
        public Person Personelss { get; set; }
    }
}
