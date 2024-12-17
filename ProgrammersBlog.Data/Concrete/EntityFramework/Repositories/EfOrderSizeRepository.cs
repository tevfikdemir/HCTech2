using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Data.Concrete.EntityFramework;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EfOrderSizeRepository : EfEntityRepositoryBase<OrderSize>, IOrderSizeRepository
    {
        public EfOrderSizeRepository(DbContext context) : base(context)
        {
        }

    }
}
