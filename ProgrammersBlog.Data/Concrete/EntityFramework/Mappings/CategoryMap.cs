﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
   public class CategoryMap:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(70);
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.CreatedByName).IsRequired();
            builder.Property(c => c.CreatedByName).HasMaxLength(50);
            builder.Property(c => c.ModifiedByName).IsRequired();
            builder.Property(c => c.ModifiedByName).HasMaxLength(50);
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.Property(c => c.Note).HasMaxLength(500);

            builder.ToTable("Categories");
            builder.HasData(
                new Category { Id = 1, Name="Makina Arızası",CreatedByName="Admin",ModifiedByName="Admin",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,IsActive=true,IsDeleted=false },
                new Category { Id = 2, Name="Elektrik Kesintisi",CreatedByName="Admin",ModifiedByName="Admin",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,IsActive=true,IsDeleted=false },
                new Category { Id = 3, Name = "Jeneratör Arızası", CreatedByName = "Admin", ModifiedByName = "Admin", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsActive = true, IsDeleted = false },
                new Category { Id = 4, Name = "Personel istifa", CreatedByName = "Admin", ModifiedByName = "Admin", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsActive = true, IsDeleted = false },
                new Category { Id = 5, Name = "Personel Münakaşa", CreatedByName = "Admin", ModifiedByName = "Admin", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsActive = true, IsDeleted = false },
                new Category { Id = 6, Name = "iş Yok", CreatedByName = "Admin", ModifiedByName = "Admin", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsActive = true, IsDeleted = false }



            );
            
        }
    }
}
