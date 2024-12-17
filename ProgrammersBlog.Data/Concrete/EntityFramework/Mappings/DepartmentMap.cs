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
   public class DepartmentMap:IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(70);
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.Description).IsRequired(false);
             
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();

            builder.ToTable("Departments");
            builder.HasData(
                new Department {Id = 1, Name = "Dikim Bölümü", IsActive = true, IsDeleted = false },
                new Department {Id = 2, Name = "Ütü Bölümü", IsActive = true, IsDeleted = false },
                new Department {Id = 3, Name = "Poşet Bölümü", IsActive = true, IsDeleted = false }




                );
        }
    }
}
