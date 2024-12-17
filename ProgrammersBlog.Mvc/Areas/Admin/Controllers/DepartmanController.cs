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
    public class DepartmanController : BaseController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmanController(IDepartmentService departmentService,UserManager<User> userManager,IMapper mapper,IImageHelper imageHelper):base(userManager,mapper,imageHelper)
        {
            _departmentService = departmentService;
        }
        [Authorize(Roles = "SuperAdmin,Department.Read")]
        public async Task<IActionResult> Index()
        {
            var result = await _departmentService.GetAllByNonDeletedAsync();
            return View(result.Data);

        }
        [Authorize(Roles = "SuperAdmin,Department.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_DepartmentAddPartial");
        }
        [Authorize(Roles = "SuperAdmin,Department.Create")]
        [HttpPost]
        public async Task<IActionResult> Add(DepartmentAddDto departmentAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _departmentService.AddAsync(departmentAddDto, LoggedInUser.UserName);
                if (result.ResultStatus==ResultStatus.Success)
                {
                    var departmanAddAjaxModel = JsonSerializer.Serialize(new DepartmentAddAjaxViewModel
                    {
                        DepartmentDto = result.Data,
                        DepartmentAddPartial = await this.RenderViewToStringAsync("_DepartmentAddPartial", departmentAddDto)
                    });
                    return Json(departmanAddAjaxModel);
                }
            }
            var departmentAddAjaxErrorModel = JsonSerializer.Serialize(new DepartmentAddAjaxViewModel
            {
                DepartmentAddPartial = await this.RenderViewToStringAsync("_DepartmentAddPartial", departmentAddDto)
            });
            return Json(departmentAddAjaxErrorModel);

        }
        [Authorize(Roles = "SuperAdmin,Department.Update")]
        [HttpGet]
        public async Task<IActionResult> Update(int departmentId)
        {
            var result = await _departmentService.GetDepartmanUpdateDtoAsync(departmentId);
            if (result.ResultStatus==ResultStatus.Success)
            {
                return PartialView("_DepartmentUpdatePartial", result.Data);
            }
            else
            {
                return NotFound();
            }
        }
        [Authorize(Roles = "SuperAdmin,Department.Update")]
        [HttpPost]
        public async Task<IActionResult> Update(DepartmentUpdateDto departmentUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _departmentService.UpdateAsync(departmentUpdateDto, LoggedInUser.UserName);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var departmanUpdateAjaxModel = JsonSerializer.Serialize(new DepartmentUpdateAjaxViewModel
                    {
                        DepartmentDto = result.Data,
                        DepartmentUpdatePartial = await this.RenderViewToStringAsync("_DepartmentUpdatePartial", departmentUpdateDto)
                    });
                    return Json(departmanUpdateAjaxModel);
                }
            }
            var departmanUpdateAjaxErrorModel = JsonSerializer.Serialize(new DepartmentUpdateAjaxViewModel
            {
                DepartmentUpdatePartial = await this.RenderViewToStringAsync("_DepartmentUpdatePartial", departmentUpdateDto)
            });
            return Json(departmanUpdateAjaxErrorModel);

        }
        [Authorize(Roles = "SuperAdmin,Department.Read")]
        [HttpGet]
        public async Task<JsonResult> GetAllDepartmans()
        {
            var result = await _departmentService.GetAllByNonDeletedAsync();
            var departments = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(departments);
        }
        [Authorize(Roles = "SuperAdmin,Department.Delete")]
        [HttpPost]
        public async Task<JsonResult> Delete(int departmentId)
        {
            var result = await _departmentService.DeleteAsync(departmentId, LoggedInUser.UserName);
            var deletedDepartment = JsonSerializer.Serialize(result.Data);
            return Json(deletedDepartment);
        }
       
         
        
        [Authorize(Roles = "SuperAdmin,Department.Delete")]
        [HttpPost]
        public async Task<JsonResult> HardDelete(int departmentId)
        {
            var result = await _departmentService.HardDeleteAsync(departmentId);
            var deletedDepartment = JsonSerializer.Serialize(result);
            return Json(deletedDepartment);
        }
    }
}
