using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Shared.Entities.Abstract;

namespace ProgrammersBlog.Entities.Concrete
{
    public class WorkHours:EntityNullBase,IEntity
    {
        public DateTime Date { get; set; } // Çalışma günü
        public TimeSpan StartTime { get; set; } // İş başı saati
        public TimeSpan EndTime { get; set; } // Paydos saati
        public TimeSpan TotalHours => EndTime - StartTime; // Toplam çalışma süresi
    }
}
