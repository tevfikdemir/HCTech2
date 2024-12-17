using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Data.Concrete.EntityFramework;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EfDepartmentRepository:EfEntityRepositoryBase<Department>,IDepartmentRepository
    {
        public EfDepartmentRepository(DbContext context) : base(context)
        {
        }

        public async Task<Department> GetById(int departmentId)
        {
            return await ProgrammersBlogContext.Departments.SingleOrDefaultAsync(c => c.Id == departmentId);
        }

        private ProgrammersBlogContext ProgrammersBlogContext
        {
            get
            {
                return _context as ProgrammersBlogContext;
            }
        }
    }
}
