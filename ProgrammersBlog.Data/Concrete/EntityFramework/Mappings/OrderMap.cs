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
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.OrderName).HasMaxLength(100);
            builder.Property(a => a.OrderName).IsRequired(true);
            builder.Property(a => a.OrderType).IsRequired();
            builder.Property(a => a.OrderType).HasColumnType("NVARCHAR(MAX)");
            builder.Property(a => a.OrderDate).IsRequired();
            builder.Property(a => a.Thumbnail).IsRequired();
            builder.Property(a => a.Thumbnail).HasMaxLength(250);
            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(50);
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.HasMany(o => o.OrderOperations).WithOne(oo => oo.Order).HasForeignKey(oo => oo.OrderId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(o => o.OrderSizes).WithOne(os => os.Order).HasForeignKey(os => os.OrderId).OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("Orders");
        }
    }
}
