using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class GetAllOperationRaporDto: DtoGetBase
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public int OperationId { get; set; }
        public string OperationName { get; set; }
        public string SizeName { get; set; }

        public int SizeId { get; set; }
        public int OrderId { get; set; }
        public int TotalQuantity { get; set; }
        public double AverageQuantity { get; set; }

        public DateTime CreatedDate { get; set; }
        public Operation Operations { get; set; }
        public Order Orders { get; set; }
        public Size Sizes { get; set; }
        public Person Persons { get; set; }
        public List<HourlyOperationCount> HourlyOperationCounts { get; set; }
        public int OperationCount { get; set; }  // Yeni eklenen alan
        public int OperationTargets { get; set; }
        public int? ConnectOperationId { get; set; }

        public int TotalOperationQuantity { get; set; }

        public int SizeTargets { get; set; }
    }
    public class HourlyOperationCount
    {
        public DateTime TimeSlot { get; set; }
        public int OpQuantity { get; set; }

    }

    public static class DateTimeExtensions
    {
        public static DateTime RoundToNearestQuarterHour(this DateTime dt)
        {
            int minutes = dt.Minute;
            int quarterHour = (minutes / 15) * 15;
            
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, quarterHour, 0);
        }
    }
}
