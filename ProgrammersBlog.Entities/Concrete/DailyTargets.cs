using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Shared.Entities.Abstract;

namespace ProgrammersBlog.Entities.Concrete
{
    public class DailyTargets : EntityBase,IEntity
    {
        public DateTime Date { get; set; } // Hedefin belirlenmiş olduğu gün
        public int Target { get; set; } // Günlük hedef
        public int WorkHoursId { get; set; } // Çalışma saatleri ile ilişki
        public WorkHours WorkHours { get; set; } // Navigation Property
    }
}
