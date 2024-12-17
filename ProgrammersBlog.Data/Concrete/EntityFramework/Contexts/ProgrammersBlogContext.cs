using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Concrete.EntityFramework.Mappings;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Contexts
{
    public class ProgrammersBlogContext:IdentityDbContext<User,Role,int,UserClaim,UserRole,UserLogin,RoleClaim,UserToken>
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Person> Persons { get; set; }
        public DbSet<DailyTargets> DailyTargets { get; set; }
        public DbSet<PersonPerformance> PersonPerformances { get; set; }
        public DbSet<WorkHours> WorkHours { get; set; }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Gorevler> Gorevler { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderSize> OrderSizes { get; set; }
        public DbSet<Operation> Operation { get; set; }
        public DbSet<OrderOperation> OrderOperations { get; set; }
        public DbSet<PersonWork> PersonWorks { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Log> Logs { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        @"Server=(localdb)\ProjectsV13;Database=ProgrammersBlog;Trusted_Connection=True;Connect Timeout=30;MultipleActiveResultSets=True;");
        //}
        public ProgrammersBlogContext(DbContextOptions<ProgrammersBlogContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoleClaimMap());
            modelBuilder.ApplyConfiguration(new UserClaimMap());
            modelBuilder.ApplyConfiguration(new UserLoginMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());
            modelBuilder.ApplyConfiguration(new UserTokenMap());
            modelBuilder.ApplyConfiguration(new LogMap());

            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new DepartmentMap());
            modelBuilder.ApplyConfiguration(new GorevlerMap());

            modelBuilder.ApplyConfiguration(new SizeMap());
            modelBuilder.ApplyConfiguration(new OperationMap());
            modelBuilder.ApplyConfiguration(new OrderMap());

            modelBuilder.ApplyConfiguration(new OrderOperationMap());
            modelBuilder.ApplyConfiguration(new OrderSizeMap());
            modelBuilder.ApplyConfiguration(new PersonWorkMap());

            modelBuilder.ApplyConfiguration(new DailyTargetsMap());
            modelBuilder.ApplyConfiguration(new PersonPerformanceMap());
            modelBuilder.ApplyConfiguration(new WorkHoursMap());


            modelBuilder.ApplyConfiguration(new CompanyMap());






        }
    }
}
