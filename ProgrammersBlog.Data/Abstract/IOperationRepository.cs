﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Data.Abstract;

namespace ProgrammersBlog.Data.Abstract
{
    public interface IOperationRepository : IEntityRepository<Operation>
    {
        Task<Operation> GetById(int operationId);
    }
}
