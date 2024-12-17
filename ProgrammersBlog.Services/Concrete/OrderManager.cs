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
using static ProgrammersBlog.Services.Utilities.Messages;
using Order = ProgrammersBlog.Entities.Concrete.Order;

namespace ProgrammersBlog.Services.Concrete
{
    public class OrderManager : ManagerBase, IOrderService
    {
        public OrderManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IDataResult<OrderDto>> GetAsync(int orderId)
        {
            var order = await UnitOfWork.Orders.GetAsync(o => o.Id == orderId,o=>o.OrderOperations, p=>p.OrderSizes);
            if (order != null)
            { 

                var orderDto = Mapper.Map<OrderDto>(order);
                return new DataResult<OrderDto>(ResultStatus.Success, orderDto);
            }
            return new DataResult<OrderDto>(ResultStatus.Error, Messages.Order.NotFound(isPlural: false), null);
        }

        public async Task<IDataResult<OrderUpdateDto>> GetOrderUpdateDtoAsync(int orderId)
        {
            var result = await UnitOfWork.Orders.AnyAsync(o => o.Id == orderId);
            if (result)
            {
                var order = await UnitOfWork.Orders.GetAsync(o => o.Id == orderId);
                var orderUpdateDto = Mapper.Map<OrderUpdateDto>(order);
                return new DataResult<OrderUpdateDto>(ResultStatus.Success, orderUpdateDto);
            }
            return new DataResult<OrderUpdateDto>(ResultStatus.Error, Messages.Order.NotFound(isPlural: false), null);
        }

        public async Task<IDataResult<OrderListDto>> GetAllAsync()
        {
            var orders = await UnitOfWork.Orders.GetAllAsync();
            if (orders.Count > -1)
            {
                var orderListDto = new OrderListDto
                {
                    Orders = Mapper.Map<IList<Order>>(orders)
                };
                return new DataResult<OrderListDto>(ResultStatus.Success, orderListDto);
            }
            return new DataResult<OrderListDto>(ResultStatus.Error, Messages.Order.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<OrderListDto>> GetAllByNonDeletedAsync()
        {
            var orders = await UnitOfWork.Orders.GetAllAsync(o => !o.IsDeleted);
            if (orders.Count > -1)
            {
                var orderListDto = new OrderListDto
                {
                    Orders = Mapper.Map<IList<Order>>(orders)
                };
                return new DataResult<OrderListDto>(ResultStatus.Success, orderListDto);
            }
            return new DataResult<OrderListDto>(ResultStatus.Error, Messages.Order.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<OrderListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var orders = await UnitOfWork.Orders.GetAllAsync(o => !o.IsDeleted && o.IsActive);
            if (orders.Count > -1)
            {
                var orderListDto = new OrderListDto
                {
                    Orders = Mapper.Map<IList<Order>>(orders)
                };
                return new DataResult<OrderListDto>(ResultStatus.Success, orderListDto);
            }
            return new DataResult<OrderListDto>(ResultStatus.Error, Messages.Order.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<OrderListDto>> GetAllByDeletedAsync()
        {
            var orders = await UnitOfWork.Orders.GetAllAsync(o => o.IsDeleted);
            if (orders.Count > -1)
            {
                var orderListDto = new OrderListDto
                {
                    Orders = Mapper.Map<IList<Order>>(orders)
                };
                return new DataResult<OrderListDto>(ResultStatus.Success, orderListDto);
            }
            return new DataResult<OrderListDto>(ResultStatus.Error, Messages.Order.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<OrderDto>> AddAsync(OrderAddDto orderAddDto, string createdByName)
        {
            var order = Mapper.Map<Order>(orderAddDto);
            order.CreatedByName = createdByName;
            order.CreatedDate = DateTime.Now;

            

            var addedOrder = await UnitOfWork.Orders.AddAsync(order);



            await UnitOfWork.SaveAsync();
            var orderDto = Mapper.Map<OrderDto>(addedOrder);
            return new DataResult<OrderDto>(ResultStatus.Success, Messages.Order.Add(addedOrder.OrderNumber), orderDto);
        }

        public async Task<IDataResult<OrderDto>> UpdateAsync(OrderUpdateDto orderUpdateDto, string modifiedByName)
        {
            var oldOrder = await UnitOfWork.Orders.GetAsync(o => o.Id == orderUpdateDto.Id);
            var order = Mapper.Map<OrderUpdateDto, Order>(orderUpdateDto, oldOrder);
            var updatedOrder = await UnitOfWork.Orders.UpdateAsync(order);
            await UnitOfWork.SaveAsync();
            var orderDto = Mapper.Map<OrderDto>(updatedOrder);
            return new DataResult<OrderDto>(ResultStatus.Success, Messages.Order.Update(updatedOrder.OrderNumber), orderDto);
        }

        public async Task<IDataResult<OrderDto>> DeleteAsync(int orderId, string modifiedByName)
        {
            var order = await UnitOfWork.Orders.GetAsync(o => o.Id == orderId);
            if (order != null)
            {
                order.IsDeleted = true;
                order.IsActive = false;
                var deletedOrder = await UnitOfWork.Orders.UpdateAsync(order);
                await UnitOfWork.SaveAsync();
                var orderDto = Mapper.Map<OrderDto>(deletedOrder);
                return new DataResult<OrderDto>(ResultStatus.Success, Messages.Order.Delete(deletedOrder.OrderNumber), orderDto);
            }
            return new DataResult<OrderDto>(ResultStatus.Error, Messages.Order.NotFound(isPlural: false), null);
        }


        public async Task<IResult> HardDeleteAsync(int orderId)
        {
            var order = await UnitOfWork.Orders.GetAsync(o => o.Id == orderId);
            if (order != null)
            {
                await UnitOfWork.Orders.DeleteAsync(order);
                await UnitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, Messages.Order.HardDelete(order.OrderNumber));
            }
            return new Result(ResultStatus.Error, Messages.Order.NotFound(isPlural: false));
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var ordersCount = await UnitOfWork.Orders.CountAsync();
            if (ordersCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, ordersCount);
            }
            return new DataResult<int>(ResultStatus.Error, "Beklenmeyen bir hata ile karşılaşıldı.", -1);
        }


        
    }


}
