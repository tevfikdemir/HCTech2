

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Mvc.Helpers.Abstract;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace ProgrammersBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RaporController : BaseController
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderService _orderService;

        private readonly IPersonWorkService _personWorkService;
        private readonly IOrderOperationService _orderOperationService;
        private readonly IMapper _mapper;
        public RaporController(IOrderService orderService,IOrderOperationService orderOperationService,IUnitOfWork unitOfWork, IPersonWorkService personWorkService, IToastNotification toastNotification, UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper) : base(userManager, mapper, imageHelper)
        {

            _personWorkService = personWorkService;
            _unitOfWork = unitOfWork;
            _orderOperationService = orderOperationService;
            _orderService= orderService;
            _mapper = mapper;
        }
        [Authorize(Roles = "SuperAdmin,Order.Read")]
        public async Task<IActionResult> Index()
        {
            var summaries = await _personWorkService.GetAllAsync();
            return View(summaries.Data);
        }

        [Authorize(Roles = "SuperAdmin,Personel.Read")]
        [HttpGet]
        public async Task<IActionResult> PersonelPerformans()
        {
            var result = await _personWorkService.GetAllPersonWorkDtosAsync();

            if (result.ResultStatus == ResultStatus.Success)
            {
                var personelperformans = new PersonPerformansListDTO
                {
                    PersonWorks = result.Data
                };

                return View(personelperformans);
            }

            // Handle error case
            //return View("Error", new ErrorViewModel { Message = result.Message });
            return NotFound();
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> GetAllPersonPerformansDtos()
        {
            var reportresult = await _personWorkService.GetAllPersonWorkDtosAsync();

            if (reportresult.ResultStatus == ResultStatus.Success)
            {
                var result = JsonSerializer.Serialize(reportresult, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                });

                if (result == null)
                {
                    return Json(new { Data = new List<object>() }); // Veri boşsa boş array döndür
                }

                return Json(new { Data = result }); // Veriyi JSON olarak dönüştürüyoruz
            }

            return Json(new { Data = new List<object>() }); // Başarısızlık durumunda boş veri döndürüyoruz
        }

        [Authorize(Roles = "SuperAdmin,Personel.Read")]
        [HttpGet]
        public async Task<JsonResult> GetAllOrdPersSizeOpr()
        {
            var result = await _personWorkService.GetAllAsync();
             
            if (result.ResultStatus == ResultStatus.Success && result.Data != null)
            {
                var groupedByPersonel = result.Data.PersonWorks
                    .GroupBy(op => new { op.PersonId, op.OperationId, op.SizeId, op.OrderId });

                var groupedSummaries = groupedByPersonel.Select(group => new
                {
                    PersonId = group.Key.PersonId,
                    PersonName = group.First().Persons.FirstName,
                    OperationId = group.Key.OperationId,
                    OperationName = group.First().Operations.OperationName,
                    SizeId = group.Key.SizeId,
                    SizeName = group.First().Sizes?.SizeName ?? "N/A",
                    OrderId = group.Key.OrderId,
                    OrderTarget = group.First().Orders.OrderQuantity,
                    OrderHedef = group.First().Orders.DayTarget,
                    TotalQuantity = group.Sum(op => op.Quantity),
                    Operations = group.First().Operations,
                    Orders = group.First().Orders,
                    Sizes = group.First().Sizes,

                    //PersonId = group.Key.PersonId,
                    //PersonName = group.First().Persons?.FirstName ?? "N/A", // Kişi adının null olmadığından emin ol
                    //OperationId = group.Key.OperationId,
                    //OperationName = group.First().Operations?.OperationName ?? "N/A", // Operasyon adının null olmadığından emin ol
                    //OperationTargets = group.First().OrderOperation?.OperationTarget ?? 0,
                    //ConnectOperationId = group.First().OrderOperation?.ConnectOperationId ?? 0,

                    //SizeId = group.Key.SizeId,
                    //SizeName = group.First().Sizes?.SizeName ?? "N/A", // Size adının null olmadığından emin ol
                    //SizeTargets = group.First().OrderSize?.SizeTarget ?? 0,
                    //OrderId = group.Key.OrderId,
                    //TotalQuantity = group.Sum(op => op.Quantity),
                    //AverageQuantity = group.Average(op => op.Quantity),
                    //Operations = group.First().Operations,
                    //Orders = group.First().Orders,
                    //Sizes = group.First().Sizes,
                    //CreatedDate = group.First().CreateDate,
                    //HourlyOperationCounts = personelTimeSlots,
                    //OperationCount = personelTimeSlots.Count,

                }).ToList();

                var ordperssizeopr = JsonSerializer.Serialize(groupedSummaries, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                });

                return Json(ordperssizeopr);
            }
            else
            {
                return Json("Error occurred while processing data.");
            }


        }

        [Authorize(Roles = "SuperAdmin,Personel.Read")]
        [HttpGet]
        public IActionResult GrafikPersonel2()
        {

            return View();
        }
        [Authorize(Roles = "SuperAdmin,Personel.Read")]
        [HttpGet]
        public IActionResult GrafikOperation()
        {
            return View();
        }


        [Authorize(Roles = "SuperAdmin,Personel.Read")]
        [HttpGet]
        public async Task<IActionResult> GetAllPersonWorkRapor()
        {
            var result = await _personWorkService.GetAllAsync();
            var groupedSummaries = new List<GetAllOperationRaporDto>();

            // Tüm işlemleri çalışan bazında grupla
            var groupedByPersonel = result.Data.PersonWorks
                .GroupBy(op => new { op.PersonId, op.OperationId, op.SizeId, op.OrderId, op.CreateDate.Date });

            foreach (var group in groupedByPersonel)
            {
                // Her çalışan için ayrı ayrı zaman dilimlerini hesaplama
                var personelTimeSlots = new List<HourlyOperationCount>();
                var startTime = group.Min(op => op.CreateDate).Date.AddHours(8); // Sabah 08:00'den başla
                var endTime = group.Max(op => op.CreateDate).Date.AddDays(1); // Gece 00:00'e kadar devam

                while (startTime < endTime)
                {
                    var nextTime = startTime.AddMinutes(15);
                    var quantityInTimeSlot = group
                        .Where(op => op.CreateDate >= startTime && op.CreateDate < nextTime)
                        .Sum(op => op.Quantity);

                    if (quantityInTimeSlot > 0)
                    {
                        personelTimeSlots.Add(new HourlyOperationCount
                        {
                            TimeSlot = startTime,
                            OpQuantity = quantityInTimeSlot
                        });
                    }
                    startTime = nextTime;
                }

                // Gruplanmış verileri kullanarak çalışan özetlerini oluşturma
                var summary = new GetAllOperationRaporDto
                {
                    PersonId = group.Key.PersonId,
                    PersonName = group.First().Persons?.FirstName ?? "N/A", // Kişi adının null olmadığından emin ol
                    OperationId = group.Key.OperationId,
                    OperationName = group.First().Operations?.OperationName ?? "N/A", // Operasyon adının null olmadığından emin ol
                    OperationTargets = group.First().OrderOperation?.OperationTarget ?? 0,
                    ConnectOperationId = group.First().OrderOperation?.ConnectOperationId ?? 0,

                    SizeId = group.Key.SizeId,
                    SizeName = group.First().Sizes?.SizeName ?? "N/A", // Size adının null olmadığından emin ol
                    SizeTargets = group.First().OrderSize?.SizeTarget ?? 0,
                    OrderId = group.Key.OrderId,
                    TotalQuantity = group.Sum(op => op.Quantity),
                    AverageQuantity = group.Average(op => op.Quantity),
                    Operations = group.First().Operations,
                    Orders = group.First().Orders,
                    Sizes = group.First().Sizes,
                    CreatedDate = group.First().CreateDate,
                    HourlyOperationCounts = personelTimeSlots,
                    OperationCount = personelTimeSlots.Count,
                };
                groupedSummaries.Add(summary);
            }

            // Operasyon bazında tüm personelin yaptığı işleri topla
            var totalOperations = groupedSummaries
                .GroupBy(gs => gs.OperationId)
                .Select(g => new
                {
                    OperationId = g.Key,
                    TotalQuantity = g.Sum(gs => gs.TotalQuantity)
                }).ToList();

            // Toplam operasyon miktarlarını groupedSummaries listesine ekle
            foreach (var summary in groupedSummaries)
            {
                var totalOperationQuantity = totalOperations
                    .FirstOrDefault(to => to.OperationId == summary.OperationId)?.TotalQuantity ?? 0;
                summary.TotalOperationQuantity = totalOperationQuantity;
            }

            // Gruplanmış özetleri sıralama ve Razor view'a iletme
            var sortedSummaries = groupedSummaries.OrderBy(op => op.OperationName).ToList();

            return View(sortedSummaries);



        }
    }
}
