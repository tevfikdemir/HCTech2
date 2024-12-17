using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Repositories
{
    public class EfPersonWorkRepository:EfEntityRepositoryBase<PersonWork>, IPersonWorkRepository
    {
        public EfPersonWorkRepository(DbContext context) : base(context)
        {
        }

        
    }
}
