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
    public class SizeController : BaseController
    {
        private readonly ISizeService _sizeService;

        public SizeController(ISizeService sizeService,UserManager<User> userManager,IMapper mapper,IImageHelper imageHelper):base(userManager,mapper,imageHelper)
        {
            _sizeService = sizeService;
        }
        [Authorize(Roles = "SuperAdmin,Size.Read")]
        public async Task<IActionResult> Index()
        {
            var result = await _sizeService.GetAllByNonDeletedAsync();
            return View(result.Data);

        }
        [Authorize(Roles = "SuperAdmin,Size.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_SizeAddPartial");
        }
        [Authorize(Roles = "SuperAdmin,Size.Create")]
        [HttpPost]
        public async Task<IActionResult> Add(SizeAddDto sizeAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _sizeService.AddAsync(sizeAddDto, LoggedInUser.UserName);
                if (result.ResultStatus==ResultStatus.Success)
                {
                    var sizeAddAjaxModel = JsonSerializer.Serialize(new SizeAddAjaxViewModel
                    {
                        SizeDto = result.Data,
                        SizeAddPartial = await this.RenderViewToStringAsync("_SizeAddPartial", sizeAddDto)
                    });
                    return Json(sizeAddAjaxModel);
                }
            }
            var sizeAddAjaxErrorModel = JsonSerializer.Serialize(new SizeAddAjaxViewModel
            {
                SizeAddPartial = await this.RenderViewToStringAsync("_SizeAddPartial", sizeAddDto)
            });
            return Json(sizeAddAjaxErrorModel);

        }
        [Authorize(Roles = "SuperAdmin,Size.Update")]
        [HttpGet]
        public async Task<IActionResult> Update(int sizeId)
        {
            var result = await _sizeService.GetSizeUpdateDtoAsync(sizeId);
            if (result.ResultStatus==ResultStatus.Success)
            {
                return PartialView("_SizeUpdatePartial",result.Data);
            }
            else
            {
                return NotFound();
            }
        }
        [Authorize(Roles = "SuperAdmin,Size.Update")]
        [HttpPost]
        public async Task<IActionResult> Update(SizeUpdateDto sizeUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _sizeService.UpdateAsync(sizeUpdateDto, LoggedInUser.UserName);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var sizeUpdateAjaxModel = JsonSerializer.Serialize(new SizeUpdateAjaxViewModel
                    {
                        SizeDto = result.Data,
                        SizeUpdatePartial = await this.RenderViewToStringAsync("_SizeUpdatePartial", sizeUpdateDto)
                    });
                    return Json(sizeUpdateAjaxModel);
                }
            }
            var sizeUpdateAjaxErrorModel = JsonSerializer.Serialize(new SizeUpdateAjaxViewModel
            {
                SizeUpdatePartial = await this.RenderViewToStringAsync("_SizeUpdatePartial", sizeUpdateDto)
            });
            return Json(sizeUpdateAjaxErrorModel);

        }
        [Authorize(Roles = "SuperAdmin,Size.Read")]
        [HttpGet]
        public async Task<JsonResult> GetAllSizes()
        {
            var result = await _sizeService.GetAllByNonDeletedAsync();
            var sizes = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(sizes);
        }
        [Authorize(Roles = "SuperAdmin,Size.Delete")]
        [HttpPost]
        public async Task<JsonResult> Delete(int sizeId)
        {
            var result = await _sizeService.DeleteAsync(sizeId, LoggedInUser.UserName);
            var deletedSize = JsonSerializer.Serialize(result.Data);
            return Json(deletedSize);
        }
          
        [Authorize(Roles = "SuperAdmin,Size.Delete")]
        [HttpPost]
        public async Task<JsonResult> HardDelete(int sizeId)
        {
            var result = await _sizeService.HardDeleteAsync(sizeId);
            var deletedSize = JsonSerializer.Serialize(result);
            return Json(deletedSize);
        }
    }
}
