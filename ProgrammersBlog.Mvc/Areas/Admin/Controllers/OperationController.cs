using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Mvc.Areas.Admin.Models;
using ProgrammersBlog.Mvc.Helpers.Abstract;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Extensions;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;

namespace ProgrammersBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OperationController : BaseController
    {
        private readonly IOperationService _operationService;

        public OperationController(IOperationService operationService,UserManager<User> userManager,IMapper mapper,IImageHelper imageHelper):base(userManager,mapper,imageHelper)
        {
            _operationService = operationService;
        }
        [Authorize(Roles = "SuperAdmin,Operation.Read")]
        public async Task<IActionResult> Index()
        {
            var result = await _operationService.GetAllByNonDeletedAsync();
            return View(result.Data);

        }
        [Authorize(Roles = "SuperAdmin,Operation.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_OperationAddPartial");
        }
        [Authorize(Roles = "SuperAdmin,Operation.Create")]
        [HttpPost]
        public async Task<IActionResult> Add(OperationAddDto operationAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _operationService.AddAsync(operationAddDto, LoggedInUser.UserName);
                if (result.ResultStatus==ResultStatus.Success)
                {
                    var operationAddAjaxModel = JsonSerializer.Serialize(new OperationAddAjaxViewModel
                    {
                        OperationDto = result.Data,
                        OperationAddPartial = await this.RenderViewToStringAsync("_OperationAddPartial", operationAddDto)
                    });
                    return Json(operationAddAjaxModel);
                }
            }
            var operationAddAjaxErrorModel = JsonSerializer.Serialize(new OperationAddAjaxViewModel
            {
                OperationAddPartial = await this.RenderViewToStringAsync("_OperationAddPartial", operationAddDto)
            });
            return Json(operationAddAjaxErrorModel);

        }
        [Authorize(Roles = "SuperAdmin,Operation.Update")]
        [HttpGet]
        public async Task<IActionResult> Update(int operationId)
        {
            var result = await _operationService.GetOperationUpdateDtoAsync(operationId);
            if (result.ResultStatus==ResultStatus.Success)
            {
                return PartialView("_OperationUpdatePartial",result.Data);
            }
            else
            {
                return NotFound();
            }
        }
        [Authorize(Roles = "SuperAdmin,Operation.Update")]
        [HttpPost]
        public async Task<IActionResult> Update(OperationUpdateDto operationUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _operationService.UpdateAsync(operationUpdateDto, LoggedInUser.UserName);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var operationUpdateAjaxModel = JsonSerializer.Serialize(new OperationUpdateAjaxViewModel
                    {
                        OperationDto = result.Data,
                        OperationUpdatePartial = await this.RenderViewToStringAsync("_OperationUpdatePartial", operationUpdateDto)
                    });
                    return Json(operationUpdateAjaxModel);
                }
            }
            var operationUpdateAjaxErrorModel = JsonSerializer.Serialize(new OperationUpdateAjaxViewModel
            {
                OperationUpdatePartial = await this.RenderViewToStringAsync("_OperationUpdatePartial", operationUpdateDto)
            });
            return Json(operationUpdateAjaxErrorModel);

        }
        [Authorize(Roles = "SuperAdmin,Operation.Read")]
        [HttpGet]
        public async Task<JsonResult> GetAllOperations()
        {
            var result = await _operationService.GetAllByNonDeletedAsync();
            var operations = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(operations);
        }
        [Authorize(Roles = "SuperAdmin,Operation.Delete")]
        [HttpPost]
        public async Task<JsonResult> Delete(int operationId)
        {
            var result = await _operationService.DeleteAsync(operationId, LoggedInUser.UserName);
            var deletedOperation = JsonSerializer.Serialize(result.Data);
            return Json(deletedOperation);
        }
         
        [Authorize(Roles = "SuperAdmin,Operation.Delete")]
        [HttpPost]
        public async Task<JsonResult> HardDelete(int operationId)
        {
            var result = await _operationService.HardDeleteAsync(operationId);
            var deletedOperation = JsonSerializer.Serialize(result);
            return Json(deletedOperation);
        }
    }
}
