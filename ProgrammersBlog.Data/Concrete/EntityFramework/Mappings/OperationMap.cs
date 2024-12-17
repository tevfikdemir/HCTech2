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
   public class OperationMap:IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.OperationName).IsRequired();
            builder.Property(c => c.OperationName).HasMaxLength(70);
            builder.Property(c => c.MakinaTipi).IsRequired();
            builder.Property(c => c.MakinaTipi).HasMaxLength(70);

            builder.Property(c => c.Description).IsRequired(false);
             
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();

            builder.ToTable("Operations");
            builder.HasData(
                new Operation { Id = 1, OperationName = "Bant Giriş", MakinaTipi = "",IsActive=true,IsDeleted=false},
                new Operation {Id = 2, OperationName = "Çevirme", MakinaTipi = "", IsActive = true, IsDeleted = false },
                new Operation {Id = 3, OperationName = "Çevirme Beden", MakinaTipi = "", IsActive = true, IsDeleted = false },
                new Operation {Id = 4, OperationName = "Ense Biye", MakinaTipi = "", IsActive = true, IsDeleted = false },
                new Operation {Id = 5, OperationName = "Etek Reçme", MakinaTipi = "", IsActive = true, IsDeleted = false },
                new Operation {Id = 6, OperationName = "Etiket Hazırlama", MakinaTipi = "", IsActive = true, IsDeleted = false },
                new Operation {Id = 7, OperationName = "Kalite", MakinaTipi = "", IsActive = true, IsDeleted = false },
                new Operation {Id = 8, OperationName = "Kol Reçme", MakinaTipi = "", IsActive = true, IsDeleted = false },
                new Operation {Id = 9, OperationName = "Kol Takma", MakinaTipi = "", IsActive = true, IsDeleted = false },
                new Operation {Id = 10, OperationName = "Omuz Çatma", MakinaTipi = "", IsActive = true, IsDeleted = false },
                new Operation {Id = 11, OperationName = "Tela Yapıştırma", MakinaTipi = "", IsActive = true, IsDeleted = false },
                new Operation {Id = 12, OperationName = "Ütü", MakinaTipi = "", IsActive = true, IsDeleted = false },
                new Operation {Id = 13, OperationName = "Yaka Basma 1.Et(Beden)", MakinaTipi = "", IsActive = true, IsDeleted = false },
                new Operation {Id = 14, OperationName = "Yaka Çıma", MakinaTipi = "", IsActive = true, IsDeleted = false },
                new Operation {Id = 15, OperationName = "Yaka iç Dikiş", MakinaTipi = "", IsActive = true, IsDeleted = false },
                new Operation {Id = 16, OperationName = "Yaka Takma", MakinaTipi = "", IsActive = true, IsDeleted = false },
                new Operation {Id = 17, OperationName = "Yaka Tıktık", MakinaTipi = "", IsActive = true, IsDeleted = false },
                new Operation {Id = 18, OperationName = "Yan Kapama", MakinaTipi = "", IsActive = true, IsDeleted = false },
                new Operation {Id = 19, OperationName = "Yıkama Kapama", MakinaTipi = "", IsActive = true, IsDeleted = false }



                );
        }
    }
}
