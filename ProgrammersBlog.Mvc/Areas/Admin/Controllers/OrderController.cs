using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Mvc.Areas.Admin.Models;
using ProgrammersBlog.Mvc.Helpers.Abstract;
using ProgrammersBlog.Shared.Utilities.Extensions;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Linq;

namespace ProgrammersBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;
        private readonly IOperationService _operationService;
        private readonly ISizeService _sizeService;
        private readonly IToastNotification _toastNotification;
        private readonly IPersonWorkService _personWorkService;
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public OrderController(ICompanyService companyService, IPersonWorkService personWorkService, IOperationService operationService, IToastNotification toastNotification, ISizeService sizeService, IOrderService orderService, UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper) : base(userManager, mapper, imageHelper)
        {
            _orderService = orderService;
            _sizeService = sizeService;
            _toastNotification = toastNotification;
            _operationService = operationService;
            _personWorkService = personWorkService;
            _companyService = companyService;
            _mapper = mapper;
        }
        [Authorize(Roles = "SuperAdmin,Order.Read")]
        public async Task<IActionResult> Index()
        {
            var result = await _orderService.GetAllByNonDeletedAsync();
            return View(result.Data);
        }

        [Authorize(Roles = "SuperAdmin,Order.Creat")]
        public async Task<IActionResult> Add()
        {
            var result = await _sizeService.GetAllByNonDeletedAsync();
            var company = await _companyService.GetAllByNonDeletedAsync();
            if (result.ResultStatus == ResultStatus.Success)
            {
                var resoper = await _operationService.GetAllByNonDeletedAsync();
                if (resoper.ResultStatus == ResultStatus.Success)
                {
                    return View(new OrderAddViewModel
                    {
                        Sizes = result.Data.Sizes,
                        Operations = resoper.Data.Operations,
                        Companies = company.Data.Companies,
                    });
                }

                return NotFound();
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOperations()
        {
            var resoper = await _operationService.GetAllByNonDeletedAsync();

             
                var operations = resoper.Data.Operations.Select(op=> new {id=op.Id,operationName=op.OperationName}).ToList();
             
            
            return Json(operations);
        }



        [Authorize(Roles = "SuperAdmin,Order.Create")]
        [HttpPost]
        public async Task<IActionResult> Add(OrderAddViewModel orderAddViewModel)
        {
            if (ModelState.IsValid)
            {
                var OperationsCount = orderAddViewModel.OrderOperations;
                var SizeCount = orderAddViewModel.OrderSizes;
                if (OperationsCount !=null  && SizeCount !=null)
                {
                    var orderAddDto = Mapper.Map<OrderAddDto>(orderAddViewModel);
                    var result = await _orderService.AddAsync(orderAddDto, LoggedInUser.UserName);
                    if (result.ResultStatus == ResultStatus.Success)
                    {
                        _toastNotification.AddSuccessToastMessage(result.Message, new ToastrOptions
                        {
                            Title = "Başarılı İşlem!"
                        });
                        return RedirectToAction("Index", "Order");
                    }
                    else
                    {
                        ModelState.AddModelError("", result.Message);
                    }
                }
                else
                {
                    if (SizeCount == null) { _toastNotification.AddErrorToastMessage("", new ToastrOptions { Title = "Beden Eklemelisiniz." }); }
                    if (OperationsCount == null) { _toastNotification.AddErrorToastMessage("", new ToastrOptions { Title = "Operasyon Eklemelisiniz." }); }
                }
            }

            var sizes = await _sizeService.GetAllByNonDeletedAsync();
            var companies = await _companyService.GetAllByNonDeletedAsync();
            var operations = await _operationService.GetAllByNonDeletedAsync();
            orderAddViewModel.Sizes = sizes.Data.Sizes;
            orderAddViewModel.Operations = operations.Data.Operations;
            orderAddViewModel.Companies = companies.Data.Companies;
            return View(orderAddViewModel);
        }

        [Authorize(Roles = "SuperAdmin,Order.Update")]
        [HttpGet]
        public async Task<IActionResult> Update(int orderId)
        {
            var result = await _orderService.GetOrderUpdateDtoAsync(orderId);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return PartialView("_OrderUpdatePartial", result.Data);
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "SuperAdmin,Order.Update")]
        [HttpPost]
        public async Task<IActionResult> Update(OrderUpdateDto orderUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _orderService.UpdateAsync(orderUpdateDto, LoggedInUser.UserName);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var orderUpdateAjaxModel = JsonSerializer.Serialize(new OrderUpdateAjaxViewModel
                    {
                        OrderDto = result.Data,
                        OrderUpdatePartial = await this.RenderViewToStringAsync("_OrderUpdatePartial", orderUpdateDto)
                    });
                    return Json(orderUpdateAjaxModel);
                }
            }
            var orderUpdateAjaxErrorModel = JsonSerializer.Serialize(new OrderUpdateAjaxViewModel
            {
                OrderUpdatePartial = await this.RenderViewToStringAsync("_OrderUpdatePartial", orderUpdateDto)
            });
            return Json(orderUpdateAjaxErrorModel);

        }

        [Authorize(Roles = "SuperAdmin,Order.Read")]
        [HttpGet]
        public async Task<JsonResult> GetAllOrders()
        {
            var result = await _orderService.GetAllByNonDeletedAsync();
            var orders = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(orders);
        }

        [Authorize(Roles = "SuperAdmin,Order.Delete")]
        [HttpPost]
        public async Task<JsonResult> Delete(int orderId)
        {
            var result = await _orderService.DeleteAsync(orderId, LoggedInUser.UserName);
            var deletedOrder = JsonSerializer.Serialize(result.Data);
            return Json(deletedOrder);
        }





    }
}
