using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Mvc.Areas.Admin.Models;
using ProgrammersBlog.Mvc.Helpers.Abstract;
using ProgrammersBlog.Mvc.Helpers.Concrete;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.Mvc.Areas.Admin.Controllers
{
    //TEst için cmd ekranında deneme yapılabilir.
    //    curl -X POST https://localhost:44328/api/data -H "Content-Type: application/json" -d "{\"OrderId\": 1,\"PersonelId\": 1,\"SizeId\": 1,\"OperationId\": 10,\"Quantity\":60}"
    //{"$id":"1","orderId":1,"personelId":1,"sizeId":1,"operationId":10,"quantity":60,"createDate":"2024-06-19T23:29:31.1084742+03:00"}

    [Route("api/[controller]")]
    [ApiController]
    public class DataController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonWorkService _personWorkService;
        private readonly IPersonService _personService;
        private readonly IOrderService _orderService;
        private readonly IOrderOperationService _orderOperationService;
        private readonly IOperationService _operationService;
        public DataController(IUnitOfWork unitOfWork, IOperationService operationService, IOrderOperationService orderOperationService, IOrderService orderService, IPersonWorkService personWorkService, IPersonService personService, UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper) : base(userManager, mapper, imageHelper)
        {
            _unitOfWork = unitOfWork;
            _personWorkService = personWorkService;
            _personService = personService;
            _orderService = orderService;
            _orderOperationService = orderOperationService;
            _operationService = operationService;
        }
        private static List<DataModel> dataStorage = new List<DataModel>();
        // POST: api/data
        [HttpPost]
        public async Task<IActionResult> PostData([FromBody] DataModel data)
        {
            if (data == null)
            {
                return BadRequest();
            }

            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    // Foreign key değerlerinin geçerliliğini kontrol edin
                    var orderOperationExists = await _unitOfWork.OrderOperation
                        .AnyAsync(o => o.OrderId == data.OrderId && o.OperationId == data.OperationId);

                    if (!orderOperationExists)
                    {
                        return BadRequest("Invalid foreign key values for OrderOperation.");
                    }


                    var model = new PersonWorkAddDto()
                    {
                        PersonId = data.PersonId,
                        OrderId = data.OrderId,
                        OperationId = data.OperationId,
                        Quantity = data.Quantity,
                        CreateDate = DateTime.Now,
                        WorkType = data.WorkType,
                        OrderOperationOperationId = data.OperationId,
                        OrderOperationOrderId = data.OrderId,
                    };

                    // Veritabanına ekleme işlemi
                    var kayit = await _personWorkService.AddAsync(model);
                    await _unitOfWork.SaveAsync();

                    // Transaction commit
                    await transaction.CommitAsync();

                    return Ok(data);
                }
                catch (DbUpdateException dbEx)
                {
                    await transaction.RollbackAsync();

                    var innerException = dbEx.InnerException;
                    var exceptionMessage = dbEx.Message;
                    while (innerException != null)
                    {
                        exceptionMessage += " | " + innerException.Message;
                        innerException = innerException.InnerException;
                    }

                    // Hata mesajını loglayın
                    Console.WriteLine("DB Update Exception: " + exceptionMessage);

                    return StatusCode(500, "Database update error: " + exceptionMessage);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();

                    var innerException = ex.InnerException;
                    var exceptionMessage = ex.Message;
                    while (innerException != null)
                    {
                        exceptionMessage += " | " + innerException.Message;
                        innerException = innerException.InnerException;
                    }

                    // Hata mesajını loglayın
                    Console.WriteLine("Exception: " + exceptionMessage);

                    return StatusCode(500, "Internal server error: " + exceptionMessage);
                }
            }
        }
        // GET: api/data/GetPerson
        [HttpGet("GetOperation")]
        public async Task<IActionResult> GetOperation(int orderId)
        {
            try
            {
                var orderOperations = await _orderOperationService.GetOrderOperationsByOrderIdAsync(orderId);
                var simplefiedoperation = orderOperations.Where(p => p.OrderId == orderId)
                    .Select(p => new
                    {
                        operationName = p.OperationName,
                        operationId = p.OperationId,
                        operationTarget = p.OperationTarget,
                    });


                if (orderOperations == null || !orderOperations.Any())
                {
                    return NotFound(new { message = "OrderOperations not found for the given OrderId." });
                }

                return Ok(simplefiedoperation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
        // GET: api/data/GetPerson
        [HttpGet("GetModel")]
        public async Task<IActionResult> GetModel()
        {
            try
            {
                var people = await _orderService.GetAllByNonDeletedAsync();

                var simplifiedPeople = people.Data.Orders.ToList().Select(p => new {
                    OrderId = p.Id,
                    modelName = p.OrderName,
                    operationQuantity = p.OrderQuantity,
                    orderNumber = p.OrderNumber,
                    dayTarget = p.DayTarget
                });

                return Ok(simplifiedPeople);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
        // GET: api/data/GetPerson
        [HttpGet("GetPerson")]
        public async Task<IActionResult> GetPerson(String CardNumber)
        {
            try
            {
                var people = await _personService.GetAllByNonDeletedAsync();

                var simplifiedPeople = people.Data.Persons
                    .Where(p => p.PersonCart == CardNumber) // Filtreleme
                    .Select(p => new {
                        PersonId = p.Id,
                        FirstName = p.FirstName,
                        PersonCart = p.PersonCart
                    })
                    ; // İlk eşleşen kişiyi al

                if (simplifiedPeople == null)
                {
                    return NotFound(); // Eşleşen kişi bulunamazsa 404 döndür
                }

                return Ok(simplifiedPeople); // Eşleşen kişinin bilgilerini döndür
            }
            catch (Exception ex)
            {
                // Hata durumunda uygun bir şekilde işleyin
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        // GET: api/data/GetPerson
        [HttpGet("GetDailyWork")]//Personel Günlük Yapılan işler Toplamı
        public async Task<IActionResult> GetDailyWork(int personId, int orderId, int operationId)
        {
            try
            {
                var personWorks = await _personWorkService.GetAllAsync();

                var filteredWorks = personWorks.Data.PersonWorks
                    .Where(p => p.OrderId == orderId && p.PersonId == personId && p.OperationId == operationId && p.WorkType == 0 && p.Quantity != 0 && p.CreateDate.Date == DateTime.Today.Date);
                var filteredWorks2 = personWorks.Data.PersonWorks
                    .Where(p => p.OrderId == orderId && p.PersonId == personId && p.OperationId == operationId && p.WorkType != 0 && p.Quantity != 0 && p.CreateDate.Date == DateTime.Today.Date);
                int totalQuantity = filteredWorks.Sum(p => p.Quantity);
                int totalQuantity2 = filteredWorks2.Sum(p => p.Quantity);

                int count = filteredWorks.Count();

                var result = new WorkSummaryDto
                {
                    TotalQuantity = totalQuantity,
                    TotalQuantity2 = totalQuantity2,
                    Count = count
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                // Hata durumunda uygun bir şekilde işleyin
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

    }
}
