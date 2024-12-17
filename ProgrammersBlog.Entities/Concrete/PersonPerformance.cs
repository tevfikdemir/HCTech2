using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Shared.Entities.Abstract;

namespace ProgrammersBlog.Entities.Concrete
{
    public class PersonPerformance : EntityBase,IEntity
    {
        public int PersonId { get; set; } // Personelin kimliği
        public DateTime Date { get; set; } // Performansın değerlendirildiği gün
        public int TasksCompleted { get; set; } // Tamamlanan iş sayısı
        public int DailyTargetId { get; set; } // Günlük hedef ile ilişki
        public DailyTargets DailyTarget { get; set; } // Navigation Property

        public double PerformancePercentage => (TasksCompleted / (double)DailyTarget.Target) * 100; // Performans yüzdesi

    }
}
