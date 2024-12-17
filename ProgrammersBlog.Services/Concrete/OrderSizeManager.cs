using AutoMapper;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Services.Utilities;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Concrete
{
    public class OrderSizeManager : ManagerBase, IOrderSizeService
    {
        public OrderSizeManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IDataResult<OrderSizeListDto>> GetAllAsync()
        {
            var orderSizes = await UnitOfWork.OrderSize.GetAllAsync();
            if (orderSizes.Count > -1)
            {
                var orderSizeListDto = new OrderSizeListDto
                {
                    OrderSizes = Mapper.Map<IList<OrderSizeDto>>(orderSizes)
                };
                return new DataResult<OrderSizeListDto>(ResultStatus.Success, orderSizeListDto);
            }
            return new DataResult<OrderSizeListDto>(ResultStatus.Error, Messages.OrderSize.NotFound(isPlural: true), null);
        }

        public Task<IDataResult<OrderSizeDto>> GetAsync(int orderId, int SizeId)
        {
            throw new NotImplementedException();
        }
        public Task<IDataResult<OrderSizeDto>> AddAsync(OrderSizeAddDto orderSizeAddDto, string createdByName)
        {
            throw new NotImplementedException();
        }


         
        public Task<IDataResult<int>> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            throw new NotImplementedException();
        }
    }

}
