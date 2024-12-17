using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class PersonPerformanceMap : IEntityTypeConfiguration<PersonPerformance>
    {
        public void Configure(EntityTypeBuilder<PersonPerformance> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Date).IsRequired();
            builder.Property(a => a.TasksCompleted).IsRequired();

            builder.HasOne(a => a.DailyTarget)
                .WithMany()
                .HasForeignKey(a => a.DailyTargetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("PersonPerformance");
        }
    }
}
