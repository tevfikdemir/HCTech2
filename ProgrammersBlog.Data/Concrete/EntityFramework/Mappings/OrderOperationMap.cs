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
    public class OrderOperationMap : IEntityTypeConfiguration<OrderOperation>
    {
        public void Configure(EntityTypeBuilder<OrderOperation> builder)
        {
            builder.HasKey(oo => new { oo.OrderId, oo.OperationId });
            builder.HasOne(oo => oo.Order).WithMany(o => o.OrderOperations).HasForeignKey(oo => oo.OrderId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(oo => oo.Operation).WithMany(op => op.OrderOperations).HasForeignKey(oo => oo.OperationId).OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("OrderOperations");
        }
    }

}
