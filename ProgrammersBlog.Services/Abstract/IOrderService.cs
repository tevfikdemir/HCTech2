using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Abstract
{
    public interface IOrderService
    {
        Task<IDataResult<OrderDto>> GetAsync(int orderId);
        Task<IDataResult<OrderUpdateDto>> GetOrderUpdateDtoAsync(int orderId);
        Task<IDataResult<OrderListDto>> GetAllAsync();

        Task<IDataResult<OrderListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<OrderListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IDataResult<OrderListDto>> GetAllByDeletedAsync();
        Task<IDataResult<OrderDto>> AddAsync(OrderAddDto orderAddDto, string createdByName);
        Task<IDataResult<OrderDto>> UpdateAsync(OrderUpdateDto orderUpdateDto, string modifiedByName);
        Task<IDataResult<OrderDto>> DeleteAsync(int orderId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int orderId);
        Task<IDataResult<int>> CountAsync();
    }
}
