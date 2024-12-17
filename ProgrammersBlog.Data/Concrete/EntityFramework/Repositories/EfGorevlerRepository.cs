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
    public class EfGorevlerRepository:EfEntityRepositoryBase<Gorevler>,IGorevlerRepository
    {
        public EfGorevlerRepository(DbContext context) : base(context)
        {
        }

        public async Task<Gorevler> GetById(int gorevlerId)
        {
            return await ProgrammersBlogContext.Gorevler.SingleOrDefaultAsync(c => c.Id == gorevlerId);
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
