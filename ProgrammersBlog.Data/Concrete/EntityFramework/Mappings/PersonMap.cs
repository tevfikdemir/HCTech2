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
    public class PersonMap:IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.FirstName).HasMaxLength(100);
            builder.Property(a => a.Description).IsRequired(false);
            builder.Property(a => a.PersonCart).IsRequired(false);


            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
            
            builder.HasOne<Department>(a => a.Department).WithMany(c => c.Persons).HasForeignKey(a => a.DepartmentId);
            builder.HasOne<Entities.Concrete.Gorevler>(a => a.Gorevler).WithMany(u => u.Persons).HasForeignKey(a => a.GorevlerId);
            builder.ToTable("Persons");
            builder.HasData(
                
                new Person { Id = 1, FirstName = "Ayşe ADADA", DepartmentId = 1, GorevlerId = 1, IsActive=true,IsDeleted=false ,PersonCart= "53 EE CC 0E" },
                new Person { Id = 2, FirstName = "Ayşe ALTUN",   DepartmentId= 2, GorevlerId = 2, IsActive=true,IsDeleted=false, PersonCart = "93 F6 A5 A5" },
                new Person {Id = 3, FirstName = "Ayşenur YETER", DepartmentId = 3, GorevlerId = 3, IsActive = true, IsDeleted = false, PersonCart = "C3 17 12 AD" },
                new Person {Id = 4, FirstName = "Baise KURTULDU", DepartmentId = 1, GorevlerId = 4, IsActive = true, IsDeleted = false , PersonCart = "B3 DB A7 15" },
                new Person {Id = 5, FirstName = "Begüm DURMAZ", DepartmentId = 2, GorevlerId = 5   , IsActive = true, IsDeleted = false , PersonCart = "" },
                new Person {Id = 6, FirstName = "Beyzanur ERTÜRK", DepartmentId = 3, GorevlerId = 2, IsActive = true, IsDeleted = false , PersonCart = "" },
                new Person {Id = 7, FirstName = "Derya KESKİN", DepartmentId = 1, GorevlerId = 2, IsActive = true, IsDeleted = false , PersonCart = "" },
                new Person {Id = 8, FirstName = "Ebru CANSU", DepartmentId = 2, GorevlerId = 3, IsActive = true, IsDeleted = false , PersonCart = "03 EB 6A 1A" },
                new Person {Id = 9, FirstName = "Emine BAYRAM", DepartmentId = 3, GorevlerId = 4, IsActive = true, IsDeleted = false , PersonCart = "" },
                new Person {Id = 10, FirstName = "Emine GAPAYLAR", DepartmentId = 1, GorevlerId = 5, IsActive = true, IsDeleted = false , PersonCart = "" },
                new Person {Id = 11, FirstName = "Emine PİŞKİN", DepartmentId = 2, GorevlerId =  1, IsActive = true, IsDeleted = false , PersonCart = "" },
                new Person {Id = 12, FirstName = "Esra DURSUN", DepartmentId =  2, GorevlerId =  2, IsActive = true, IsDeleted = false , PersonCart = "" },
                new Person {Id = 13, FirstName = "Fadime SAATCİ", DepartmentId =  3, GorevlerId =  3, IsActive = true, IsDeleted = false , PersonCart = "" },
                new Person {Id = 14, FirstName = "Hazime AVCI", DepartmentId = 1 , GorevlerId =  4, IsActive = true, IsDeleted = false , PersonCart = "" },
                new Person {Id = 15, FirstName = "Hayal ŞENER", DepartmentId = 2, GorevlerId =  5, IsActive = true, IsDeleted = false , PersonCart = "" },
                new Person {Id = 16, FirstName = "Fatma BALCI", DepartmentId = 3, GorevlerId = 1 , IsActive = true, IsDeleted = false , PersonCart = "" },
                new Person {Id = 17, FirstName = "Fatma KIZILTAN", DepartmentId = 2, GorevlerId = 2, IsActive = true, IsDeleted = false , PersonCart = "" },
                new Person {Id = 18, FirstName = "Faruk BİÇER",     DepartmentId = 1 , GorevlerId = 3, IsActive = true, IsDeleted = false , PersonCart = "" },
                new Person {Id = 19, FirstName = "Gülcan MUHTANCI", DepartmentId = 1 , GorevlerId = 4, IsActive = true, IsDeleted = false , PersonCart = "" },
                new Person {Id = 20, FirstName = "Güler SAĞCAN", DepartmentId = 2 , GorevlerId = 5, IsActive = true, IsDeleted = false , PersonCart = "" },
                new Person {Id = 21, FirstName = "Hanife BOZKURT", DepartmentId = 2, GorevlerId = 1, IsActive = true, IsDeleted = false , PersonCart = "" },
                new Person { Id = 22, FirstName = "Hatice ÖZDİL", DepartmentId = 2, GorevlerId = 1, IsActive = true, IsDeleted = false , PersonCart = "" },
                new Person { Id = 23, FirstName = "Hava SUBAŞI", DepartmentId = 2, GorevlerId = 1, IsActive = true, IsDeleted = false , PersonCart = "" },
                new Person { Id = 24, FirstName = "Hayal ŞENER", DepartmentId = 2, GorevlerId = 1, IsActive = true, IsDeleted = false , PersonCart = "" }

                );

           
        }
    }
}
