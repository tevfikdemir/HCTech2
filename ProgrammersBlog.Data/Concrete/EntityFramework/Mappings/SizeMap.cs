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
   public class SizeMap:IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.SizeName).IsRequired();
            builder.Property(c => c.SizeName).HasMaxLength(70);
            builder.Property(c => c.Description).IsRequired(false);
             
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();

            builder.ToTable("Sizes");
            builder.HasData(
                new Size { Id = 1, SizeName = "L",IsActive=true,IsDeleted=false},
                new Size {Id = 2, SizeName = "XL", IsActive = true, IsDeleted = false },
                new Size {Id = 3, SizeName = "XXL", IsActive = true, IsDeleted = false },
                new Size { Id = 4, SizeName = "XXXL",IsActive = true, IsDeleted = false },
                new Size {Id = 5, SizeName = "S", IsActive = true, IsDeleted = false },
                new Size { Id = 6, SizeName = "M", IsActive = true, IsDeleted = false },
                new Size { Id = 7, SizeName = "XS",  IsActive = true, IsDeleted = false }


                );




                }
    }
}
