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
    public class PersonWorkMap:IEntityTypeConfiguration<PersonWork>
    {
        public void Configure(EntityTypeBuilder<PersonWork> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.CreateDate).IsRequired();
            builder.Property(a => a.Quantity).IsRequired().HasDefaultValue(0); // Added default value for Quantity
            builder.HasOne(a => a.Orders)
                .WithMany(c => c.PersonWorks).HasForeignKey(a => a.OrderId).OnDelete(DeleteBehavior.Restrict); // Added OnDelete behavior
            builder.HasOne(a => a.Persons)
                .WithMany(c => c.PersonWorks).HasForeignKey(a => a.PersonId).OnDelete(DeleteBehavior.Restrict); // Added OnDelete behavior
             
            builder.HasOne(a => a.Operations)
                .WithMany(c => c.PersonWorks).HasForeignKey(a => a.OperationId).OnDelete(DeleteBehavior.Restrict); // Added OnDelete behavior
            //builder.HasOne(a => a.OrderOperation)
            //    .WithOne()
            //    .HasForeignKey<PersonWork>(a => new { a.OrderOperationOrderId, a.OrderOperationOperationId })
            //    .OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("PersonWorks");
        }
    }
}
