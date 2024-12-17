using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Abstract
{
    public interface IOrderSizeService
    {
        Task<IDataResult<OrderSizeDto>> GetAsync(int orderId, int SizeId);
        Task<IDataResult<OrderSizeListDto>> GetAllAsync();
        Task<IDataResult<OrderSizeDto>> AddAsync(OrderSizeAddDto orderSizeAddDto, string createdByName);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
