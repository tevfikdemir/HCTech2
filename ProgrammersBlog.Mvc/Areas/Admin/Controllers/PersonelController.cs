using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete;
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
    public class PersonelController : BaseController
    {
        private readonly IPersonService _personService;
        private readonly IDepartmentService _departmentService;
        private readonly IUnitOfWork _unitOfWork;
        public PersonelController(IUnitOfWork unitOfWork,IDepartmentService departmanService,IPersonService personService,UserManager<User> userManager,IMapper mapper,IImageHelper imageHelper):base(userManager,mapper,imageHelper)
        {
            _personService = personService;
            _unitOfWork = unitOfWork;
            _departmentService = departmanService;
        }
        [Authorize(Roles = "SuperAdmin,Person.Read")]
        public async Task<IActionResult> Index()
        {
            var result = await _personService.GetAllByNonDeletedAsync();
           
            return View(result.Data);

        }
        [Authorize(Roles = "SuperAdmin,Person.Create")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var departmanlar = await _unitOfWork.Department.GetAllAsync();
            var gorevler = await _unitOfWork.Gorevler.GetAllAsync();
            var departmanList = departmanlar.Select(d => new SelectListItem{Value = d.Id.ToString(),Text = d.Name}).ToList();
            if(departmanlar.Count == 0) 
            { 
                departmanList.Insert(0, new SelectListItem { Value = "", Text = "Öncelikle Departman Eklemelisiniz" });
            }
            else
            {
                departmanList.Insert(0, new SelectListItem { Value = "", Text = "Departman Seçiniz" });
            }

            var gorevlerList = gorevler.Select(g => new SelectListItem{Value = g.Id.ToString(),Text = g.Name}).ToList();
            if (gorevler.Count == 0)
            {
                gorevlerList.Insert(0, new SelectListItem { Value = "", Text = "Öncelikle Görev Eklemelisiniz" });
            }
            else
            {
                gorevlerList.Insert(0, new SelectListItem { Value = "", Text = "Görev Seçiniz" });
            }

            ViewBag.Departmanlar = new SelectList(departmanList, "Value", "Text");
            ViewBag.Gorevler = new SelectList(gorevlerList, "Value", "Text");
            return PartialView("_PersonAddPartial");
        }
        [Authorize(Roles = "SuperAdmin,Person.Create")]
        [HttpPost]
        public async Task<IActionResult> Add(PersonAddDto personAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _personService.AddAsync(personAddDto, LoggedInUser.UserName);
                if (result.ResultStatus==ResultStatus.Success)
                {
                    var personAddAjaxModel = JsonSerializer.Serialize(new PersonAddAjaxViewModel
                    {
                        PersonDto = result.Data,
                        PersonAddPartial = await this.RenderViewToStringAsync("_PersonAddPartial", personAddDto)
                    });
                    return Json(personAddAjaxModel);
                }
            }
            var personelAddAjaxErrorModel = JsonSerializer.Serialize(new PersonAddAjaxViewModel
            {
                PersonAddPartial = await this.RenderViewToStringAsync("_PersonAddPartial", personAddDto)
            });
            return Json(personelAddAjaxErrorModel);

        }
        [Authorize(Roles = "SuperAdmin,Person.Update")]
        [HttpGet]
        public async Task<IActionResult> Update(int personId)
        {
            var result = await _personService.GetPersonelUpdateDtoAsync(personId);
            if (result.ResultStatus==ResultStatus.Success)
            {
                var departmanResult = await _departmentService.GetAllByNonDeletedAsync();
                var sonuc = Mapper.Map<PersonUpdateDto>(result.Data);
                    sonuc.Departments = departmanResult.Data.Departments;

                return PartialView("_PersonUpdatePartial", sonuc);
            }
            else
            {
                return NotFound();
            }
        }
        [Authorize(Roles = "SuperAdmin,Person.Update")]
        [HttpPost]
        public async Task<IActionResult> Update(PersonUpdateDto personUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _personService.UpdateAsync(personUpdateDto, LoggedInUser.UserName);

                if (result.ResultStatus == ResultStatus.Success)
                {
                    var departmanResult = await _departmentService.GetAllByNonDeletedAsync();
                    personUpdateDto.Departments = departmanResult.Data.Departments;
                    var personUpdateAjaxModel = JsonSerializer.Serialize(new PersonUpdateAjaxViewModel
                    {
                        
                        PersonDto = result.Data,
                        PersonUpdatePartial = await this.RenderViewToStringAsync("_PersonUpdatePartial", personUpdateDto)
                    });
                    return Json(personUpdateAjaxModel);
                }
            }
            var personUpdateAjaxErrorModel = JsonSerializer.Serialize(new PersonUpdateAjaxViewModel
            {
                PersonUpdatePartial = await this.RenderViewToStringAsync("_PersonUpdatePartial", personUpdateDto)
            });
            return Json(personUpdateAjaxErrorModel);

        }
        [Authorize(Roles = "SuperAdmin,Person.Read")]
        [HttpGet]
        public async Task<JsonResult> GetAllPersonels()
        {
            var result = await _personService.GetAllByNonDeletedAsync();
            var persons = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(persons);
        }
        [Authorize(Roles = "SuperAdmin,Person.Delete")]
        [HttpPost]
        public async Task<JsonResult> Delete(int personId)
        {
            var result = await _personService.DeleteAsync(personId, LoggedInUser.UserName);
            var deletedPerson = JsonSerializer.Serialize(result.Data);
            return Json(deletedPerson);
        }
         
         
        [Authorize(Roles = "SuperAdmin,Person.Delete")]
        [HttpPost]
        public async Task<JsonResult> HardDelete(int personelId)
        {
            var result = await _personService.HardDeleteAsync(personelId);
            var deletedPerson = JsonSerializer.Serialize(result);
            return Json(deletedPerson);
        }
    }
}
