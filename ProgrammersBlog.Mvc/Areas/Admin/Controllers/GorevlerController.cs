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
    public class GorevlerController : BaseController
    {
        private readonly IGorevlerService _gorevlerService;

        public GorevlerController(IGorevlerService gorevlerService,UserManager<User> userManager,IMapper mapper,IImageHelper imageHelper):base(userManager,mapper,imageHelper)
        {
            _gorevlerService = gorevlerService;
        }
        [Authorize(Roles = "SuperAdmin,Gorevler.Read")]
        public async Task<IActionResult> Index()
        {
            var result = await _gorevlerService.GetAllByNonDeletedAsync();
            return View(result.Data);

        }
        [Authorize(Roles = "SuperAdmin,Gorevler.Create")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_GorevlerAddPartial");
        }
        [Authorize(Roles = "SuperAdmin,Gorevler.Create")]
        [HttpPost]
        public async Task<IActionResult> Add(GorevlerAddDto gorevlerAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _gorevlerService.AddAsync(gorevlerAddDto, LoggedInUser.UserName);
                if (result.ResultStatus==ResultStatus.Success)
                {
                    var gorevlerAddAjaxModel = JsonSerializer.Serialize(new GorevlerAddAjaxViewModel
                    {
                        GorevlerDto = result.Data,
                        GorevlerAddPartial = await this.RenderViewToStringAsync("_GorevlerAddPartial", gorevlerAddDto)
                    });
                    return Json(gorevlerAddAjaxModel);
                }
            }
            var gorevlerAddAjaxErrorModel = JsonSerializer.Serialize(new GorevlerAddAjaxViewModel
            {
                GorevlerAddPartial = await this.RenderViewToStringAsync("_GorevlerAddPartial", gorevlerAddDto)
            });
            return Json(gorevlerAddAjaxErrorModel);

        }
        [Authorize(Roles = "SuperAdmin,Gorevler.Update")]
        [HttpGet]
        public async Task<IActionResult> Update(int gorevlerId)
        {
            var result = await _gorevlerService.GetGorevlerUpdateDtoAsync(gorevlerId);
            if (result.ResultStatus==ResultStatus.Success)
            {
                return PartialView("_GorevlerUpdatePartial", result.Data);
            }
            else
            {
                return NotFound();
            }
        }
        [Authorize(Roles = "SuperAdmin,Gorevler.Update")]
        [HttpPost]
        public async Task<IActionResult> Update(GorevlerUpdateDto gorevlerUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _gorevlerService.UpdateAsync(gorevlerUpdateDto, LoggedInUser.UserName);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var gorevlerUpdateAjaxModel = JsonSerializer.Serialize(new GorevlerUpdateAjaxViewModel
                    {
                        GorevlerDto = result.Data,
                        GorevlerUpdatePartial = await this.RenderViewToStringAsync("_GorevlerUpdatePartial", gorevlerUpdateDto)
                    });
                    return Json(gorevlerUpdateAjaxModel);
                }
            }
            var gorevlerUpdateAjaxErrorModel = JsonSerializer.Serialize(new GorevlerUpdateAjaxViewModel
            {
                GorevlerUpdatePartial = await this.RenderViewToStringAsync("_GorevlerUpdatePartial", gorevlerUpdateDto)
            });
            return Json(gorevlerUpdateAjaxErrorModel);

        }
        [Authorize(Roles = "SuperAdmin,Gorevler.Read")]
        [HttpGet]
        public async Task<JsonResult> GetAllGorevs()
        {
            var result = await _gorevlerService.GetAllByNonDeletedAsync();
            var gorevs = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(gorevs);
        }
        [Authorize(Roles = "SuperAdmin,Gorevler.Delete")]
        [HttpPost]
        public async Task<JsonResult> Delete(int gorevlerId)
        {
            var result = await _gorevlerService.DeleteAsync(gorevlerId, LoggedInUser.UserName);
            var deletedGorevler = JsonSerializer.Serialize(result.Data);
            return Json(deletedGorevler);
        }
        
      
        [Authorize(Roles = "SuperAdmin,Gorevler.Update")]
        [HttpPost]
   
        [Authorize(Roles = "SuperAdmin,Gorevler.Delete")]
        [HttpPost]
        public async Task<JsonResult> HardDelete(int gorevlerId)
        {
            var result = await _gorevlerService.HardDeleteAsync(gorevlerId);
            var deletedGorevler = JsonSerializer.Serialize(result);
            return Json(deletedGorevler);
        }
    }
}
