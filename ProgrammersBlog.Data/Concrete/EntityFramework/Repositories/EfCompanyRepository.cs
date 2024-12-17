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
    public class EfCompanyRepository:EfEntityRepositoryBase<Company>,ICompanyRepository
    {
        public EfCompanyRepository(DbContext context) : base(context)
        {
        }

        public async Task<Company> GetById(int companyId)
        {
            return await ProgrammersBlogContext.Companies.SingleOrDefaultAsync(c => c.Id == companyId);
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
