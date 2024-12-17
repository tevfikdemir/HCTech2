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
    public class EfSizeRepository:EfEntityRepositoryBase<Size>,ISizeRepository
    {
        public EfSizeRepository(DbContext context) : base(context)
        {
        }

        public async Task<Size> GetById(int sizeId)
        {
            return await ProgrammersBlogContext.Sizes.SingleOrDefaultAsync(c => c.Id == sizeId);
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
