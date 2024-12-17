using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Data.Concrete.EntityFramework;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EfPersonRepository:EfEntityRepositoryBase<Person>,IPersonRepository
    {
        public EfPersonRepository(DbContext context) : base(context)
        {
        }
        public async Task<Person> GetById(int personId)
        {
            return await ProgrammersBlogContext.Persons.SingleOrDefaultAsync(c => c.Id == personId);
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
