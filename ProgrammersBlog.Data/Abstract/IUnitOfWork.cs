using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        Task<IDbContextTransaction> BeginTransactionAsync();
        IArticleRepository Articles { get; } // unitofwork.Articles
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }

        IPersonRepository Persons { get; }
        IDepartmentRepository Department { get; }
        IGorevlerRepository Gorevler { get; }
        ISizeRepository Size { get; }  
        IOrderRepository Orders { get; }
        IOrderSizeRepository OrderSize { get; }
        IOperationRepository Operation { get; }
        IOrderOperationRepository OrderOperation { get; }
        ICompanyRepository Companies { get; }
        IPersonWorkRepository PersonWorks { get; }

        // _unitOfWork.Categories.AddAsync();
        // _unitOfWork.Categories.AddAsync(category);
        //_unitOfWork.Users.AddAsync(user);
        //_unitOfWork.SaveAsync();


        Task<int> SaveAsync();
    }
}
