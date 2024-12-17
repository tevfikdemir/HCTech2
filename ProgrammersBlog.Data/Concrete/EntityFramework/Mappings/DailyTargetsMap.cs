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
    public class DailyTargetsMap : IEntityTypeConfiguration<DailyTargets>
    {
        public void Configure(EntityTypeBuilder<DailyTargets> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Date).IsRequired();
            builder.Property(a => a.Target).IsRequired();

            builder.HasOne(a => a.WorkHours)
                .WithMany()
                .HasForeignKey(a => a.WorkHoursId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("DailyTargets");
        }
    }
}
