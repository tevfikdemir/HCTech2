using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;
using ProgrammersBlog.Data.Concrete.EntityFramework.Repositories;

namespace ProgrammersBlog.Data.Concrete
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ProgrammersBlogContext _context;
        private EfArticleRepository _articleRepository;
        private EfCategoryRepository _categoryRepository;
        private EfCommentRepository _commentRepository;

        private EfPersonRepository _personRepository;
        private EfDepartmentRepository _departmentRepository;
        private EfGorevlerRepository _gorevlerRepository;
        private EfSizeRepository _sizeRepository;
        private EfOrderRepository _orderRepository;
        private EfOrderSizeRepository _orderSizeRepository;
        private EfOperationRepository _operationRepository;
        private EfOrderOperationRepository _orderOperationRepository;
        private EfCompanyRepository _companyRepository;
        private EfPersonWorkRepository _personWorkRepository;

        private EfDailyTargetsRepository _dailyTargetsRepository;
        private EfPersonPerformanceRepository _personPerformanceRepository;
        private EfWorkHoursRepository _workHoursRepository;

        public UnitOfWork(ProgrammersBlogContext context)
        {
            _context = context;
        }

        public IArticleRepository Articles => _articleRepository ??= new EfArticleRepository(_context);
        public ICategoryRepository Categories => _categoryRepository ??= new EfCategoryRepository(_context);
        public ICommentRepository Comments => _commentRepository ??= new EfCommentRepository(_context);
        public IPersonRepository Persons => _personRepository ??= new EfPersonRepository(_context);
        public IDepartmentRepository Department => _departmentRepository ??=new EfDepartmentRepository(_context);
        public IGorevlerRepository Gorevler => _gorevlerRepository ??= new EfGorevlerRepository(_context);
        public ISizeRepository Size => _sizeRepository ??=new EfSizeRepository(_context);
        public IOrderRepository Orders =>  _orderRepository ??=new EfOrderRepository(_context);
        public IOrderSizeRepository OrderSize => _orderSizeRepository ??=new EfOrderSizeRepository(_context);
        public IOperationRepository Operation => _operationRepository ??= new EfOperationRepository(_context);
        public IOrderOperationRepository OrderOperation => _orderOperationRepository ??=new EfOrderOperationRepository(_context);
        public ICompanyRepository Companies => _companyRepository   ??=new EfCompanyRepository(_context);
        public IPersonWorkRepository PersonWorks => _personWorkRepository ??= new EfPersonWorkRepository(_context);

        public IDailyTargetsRepository  DailyTargets => _dailyTargetsRepository ??=new EfDailyTargetsRepository(_context);
        public IPersonPerformanceRepository PersonPerformance => _personPerformanceRepository ??=new EfPersonPerformanceRepository(_context);
        public IWorkHoursRepository WorkHours => _workHoursRepository ??=new EfWorkHoursRepository(_context);


        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return  await _context.Database.BeginTransactionAsync();
        }
    }
}
