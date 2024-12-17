using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Abstract
{
    public interface  IOrderOperationService
    {
        Task<IDataResult<OrderOperationDto>> GetAsync(int orderId, int operationId);
        Task<IDataResult<OrderOperationListDto>> GetAllAsync();
        Task<IDataResult<OrderOperationListDto>> GetAllByNonDeletedAsync();
        Task<IList<OrderOperationDto>> GetOrderOperationsByOrderIdAsync(int orderId);

        Task<IDataResult<OrderOperationListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IDataResult<OrderOperationDto>> AddAsync(OrderOperationAddDto orderoperationAddDto, string createdByName);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
