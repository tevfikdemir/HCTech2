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
    public class OrderSizeMap:IEntityTypeConfiguration<OrderSize>
    {
        public void Configure(EntityTypeBuilder<OrderSize> builder)
        {
            builder.HasKey(os => new { os.OrderId, os.SizeId });
            builder.HasOne(os => os.Order).WithMany(o => o.OrderSizes).HasForeignKey(os => os.OrderId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(os => os.Size).WithMany(s => s.OrderSizes).HasForeignKey(os => os.SizeId).OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("OrderSizes");
        }
    }
}
