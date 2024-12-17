using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Entities.Abstract
{
    public abstract class EntityCrossBase 
    {
         
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;

    }
}
