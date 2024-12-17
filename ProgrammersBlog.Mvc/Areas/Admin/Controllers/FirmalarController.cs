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
    public class FirmalarController : BaseController
    {
        private readonly ICompanyService _companyService;

        public FirmalarController(ICompanyService companyService, UserManager<User> userManager,IMapper mapper,IImageHelper imageHelper):base(userManager,mapper,imageHelper)
        {
            _companyService = companyService;
        }
        [Authorize(Roles = "SuperAdmin,Firmalar.Read")]
        public async Task<IActionResult> Index()
        {
            var result = await _companyService.GetAllByNonDeletedAsync();
            return View(result.Data);

        }
        [Authorize(Roles = "SuperAdmin,Firmalar.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_CompanyAddPartial");
        }
        [Authorize(Roles = "SuperAdmin,Firmalar.Create")]
        [HttpPost]
        public async Task<IActionResult> Add(CompanyAddDto companyAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _companyService.AddAsync(companyAddDto, LoggedInUser.UserName);
                if (result.ResultStatus==ResultStatus.Success)
                {
                    var firmalarAddAjaxModel = JsonSerializer.Serialize(new CompanyAddAjaxViewModel
                    {
                        CompanyDto = result.Data,
                        CompanyAddPartial = await this.RenderViewToStringAsync("_CompanyAddPartial", companyAddDto)
                    });
                    return Json(firmalarAddAjaxModel);
                }
            }
            var companyAddAjaxErrorModel = JsonSerializer.Serialize(new CompanyAddAjaxViewModel
            {
                CompanyAddPartial = await this.RenderViewToStringAsync("_CompanyAddPartial", companyAddDto)
            });
            return Json(companyAddAjaxErrorModel);

        }
        [Authorize(Roles = "SuperAdmin,Firmalar.Update")]
        [HttpGet]
        public async Task<IActionResult> Update(int companyId)
        {
            var result = await _companyService.GetFirmalarUpdateDtoAsync(companyId);
            if (result.ResultStatus==ResultStatus.Success)
            {
                return PartialView("_CompanyUpdatePartial",result.Data);
            }
            else
            {
                return NotFound();
            }
        }
        [Authorize(Roles = "SuperAdmin,Firmalar.Update")]
        [HttpPost]
        public async Task<IActionResult> Update(CompanyUpdateDto companyUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _companyService.UpdateAsync(companyUpdateDto, LoggedInUser.UserName);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var companyUpdateAjaxModel = JsonSerializer.Serialize(new CompanyUpdateAjaxViewModel
                    {
                        CompanyDto = result.Data,
                        CompanyUpdatePartial = await this.RenderViewToStringAsync("_CompanyUpdatePartial", companyUpdateDto)
                    });
                    return Json(companyUpdateAjaxModel);
                }
            }
            var companyUpdateAjaxErrorModel = JsonSerializer.Serialize(new CompanyUpdateAjaxViewModel
            {
                CompanyUpdatePartial = await this.RenderViewToStringAsync("_CompanyUpdatePartial", companyUpdateDto)
            });
            return Json(companyUpdateAjaxErrorModel);

        }
        [Authorize(Roles = "SuperAdmin,Firmalar.Read")]
        [HttpGet]
        public async Task<JsonResult> GetAllFirmalars()
        {
            var result = await _companyService.GetAllByNonDeletedAsync();
            var company = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(company);
        }
        [Authorize(Roles = "SuperAdmin,Firmalar.Delete")]
        [HttpPost]
        public async Task<JsonResult> Delete(int companyId)
        {
            var result = await _companyService.DeleteAsync(companyId, LoggedInUser.UserName);
            var deletedFirmalar= JsonSerializer.Serialize(result.Data);
            return Json(deletedFirmalar);
        }
         
         
        [Authorize(Roles = "SuperAdmin,Firmalar.Delete")]
        [HttpPost]
        public async Task<JsonResult> HardDelete(int companyId)
        {
            var result = await _companyService.HardDeleteAsync(companyId);
            var deletedFirmalar = JsonSerializer.Serialize(result);
            return Json(deletedFirmalar);
        }
    }
}
