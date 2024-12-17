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
    public class EfOperationRepository:EfEntityRepositoryBase<Operation>,IOperationRepository
    {
        public EfOperationRepository(DbContext context) : base(context)
        {
        }

        public async Task<Operation> GetById(int operationId)
        {
            return await ProgrammersBlogContext.Operation.SingleOrDefaultAsync(c => c.Id == operationId);
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
