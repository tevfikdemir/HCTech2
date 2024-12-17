using AutoMapper;
using Microsoft.AspNetCore.Razor.Language;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Services.Utilities;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Concrete
{
    public class OrderOperationManager : ManagerBase, IOrderOperationService
    {
        public OrderOperationManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IDataResult<OrderOperationDto>> GetAsync(int orderId, int operationId)
        {
            var order = await UnitOfWork.OrderOperation.GetAsync(o => o.OperationId == operationId);
            if (order != null)
            {
                var orderDto = Mapper.Map<OrderOperationDto>(order);
                return new DataResult<OrderOperationDto>(ResultStatus.Success, orderDto);
            }
            return new DataResult<OrderOperationDto>(ResultStatus.Error, Messages.Order.NotFound(isPlural: false), null);
        }
        public async Task<IDataResult<OrderOperationListDto>> GetAllAsync()
        {
            var orders = await UnitOfWork.OrderOperation.GetAllAsync();
            if (orders.Count > -1)
            {
                var orderListDto = new OrderOperationListDto
                {
                    OrderOperations = Mapper.Map<IList<OrderOperationDto>>(orders)
                };
                return new DataResult<OrderOperationListDto>(ResultStatus.Success, orderListDto);
            }
            return new DataResult<OrderOperationListDto>(ResultStatus.Error, Messages.Order.NotFound(isPlural: true), null);
        }
        public async Task<IDataResult<OrderOperationListDto>> GetAllByNonDeletedAsync()
        {
            var orders = await UnitOfWork.OrderOperation.GetAllAsync(o => !o.IsDeleted,p=>p.OperationTarget);
            if (orders.Count > -1)
            {
                var orderListDto = new OrderOperationListDto
                {
                    OrderOperations = Mapper.Map<IList<OrderOperationDto>>(orders)
                };
                return new DataResult<OrderOperationListDto>(ResultStatus.Success, orderListDto);
            }
            return new DataResult<OrderOperationListDto>(ResultStatus.Error, Messages.Order.NotFound(isPlural: true), null);
        }

        public async Task<IList<OrderOperationDto>> GetOrderOperationsByOrderIdAsync(int orderId)
        {
            var orderOperations = await UnitOfWork.OrderOperation.GetAllAsync(
        oo => oo.OrderId == orderId,
        oo => oo.Operation  // Operation ilişkisini dahil edin
    );

            var orderOperationDtos = orderOperations.Select(oo => new OrderOperationDto
            {
                OperationId = oo.OperationId,
                OrderId = oo.OrderId,
                OperationTarget = oo.OperationTarget,
                ConnectOperationId = oo.ConnectOperationId,
                OperationName = oo.Operation?.OperationName  // OperationName alanını ekleyin
            }).ToList();

            return orderOperationDtos;
        }
        public async Task<IDataResult<OrderOperationListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var orders = await UnitOfWork.OrderOperation.GetAllAsync(o => !o.IsDeleted && o.IsActive);
            if (orders.Count > -1)
            {
                var orderListDto = new OrderOperationListDto
                {
                    OrderOperations = Mapper.Map<IList<OrderOperationDto>>(orders)
                };
                return new DataResult<OrderOperationListDto>(ResultStatus.Success, orderListDto);
            }
            return new DataResult<OrderOperationListDto>(ResultStatus.Error, Messages.Order.NotFound(isPlural: true), null);
        }
        public async Task<IDataResult<OrderOperationDto>> AddAsync(OrderOperationAddDto orderAddDto, string createdByName)
        {
            var order = Mapper.Map<OrderOperation>(orderAddDto);
            var addedOrder = await UnitOfWork.OrderOperation.AddAsync(order);
            await UnitOfWork.SaveAsync();
            var orderDto = Mapper.Map<OrderOperationDto>(addedOrder);
            return new DataResult<OrderOperationDto>(ResultStatus.Success, Messages.Order.Add(addedOrder.OperationId.ToString()), orderDto);
        }
        public async Task<IDataResult<int>> CountAsync()
        {
            var ordersCount = await UnitOfWork.OrderOperation.CountAsync();
            if (ordersCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, ordersCount);
            }
            return new DataResult<int>(ResultStatus.Error, "Beklenmeyen bir hata ile karşılaşıldı.", -1);
        }
        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var ordersCount = await UnitOfWork.OrderOperation.CountAsync(o => !o.IsDeleted);
            if (ordersCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, ordersCount);
            }
            return new DataResult<int>(ResultStatus.Error, "Beklenmeyen bir hata ile karşılaşıldı.", -1);
        }
    }

}
