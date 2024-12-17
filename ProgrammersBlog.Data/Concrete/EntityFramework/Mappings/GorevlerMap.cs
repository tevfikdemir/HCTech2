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
   public class GorevlerMap:IEntityTypeConfiguration<Gorevler>
    {
        public void Configure(EntityTypeBuilder<Gorevler> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(70);
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.Description).IsRequired(false);
             
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();

            builder.ToTable("Gorevler");
            builder.HasData(
                new Gorevler {Id = 1, Name = "Makinacı", IsActive = true, IsDeleted = false },
                new Gorevler {Id = 2, Name = "Ütücü", IsActive = true, IsDeleted = false },
                new Gorevler {Id = 3, Name = "Ayakcı", IsActive = true, IsDeleted = false },
                new Gorevler {Id = 4, Name = "Ayakcı Makinacı", IsActive = true, IsDeleted = false },
                new Gorevler {Id = 5, Name = "İp Temizlemeci", IsActive = true, IsDeleted = false }


                );
             
        }
    }
}
