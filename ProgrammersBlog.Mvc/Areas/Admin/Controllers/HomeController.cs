using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Mvc.Areas.Admin.Models;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;

namespace ProgrammersBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;
        private readonly IOrderService _orderService;
        private readonly IPersonService _personService;

        private readonly UserManager<User> _userManager;

        public HomeController(IPersonService personService,IOrderService orderService,ICategoryService categoryService, IArticleService articleService, ICommentService commentService, UserManager<User> userManager)
        {
            _categoryService = categoryService;
            _articleService = articleService;
            _commentService = commentService;
            _orderService = orderService;
            _personService = personService;
            _userManager = userManager;
        }
        [Authorize(Roles = "SuperAdmin,AdminArea.Home.Read")]
        public async Task<IActionResult> Index()
        {
            var categoriesCountResult = await _categoryService.CountByNonDeletedAsync();
            var articlesCountResult = await _articleService.CountByNonDeletedAsync();
            var commentsCountResult = await _commentService.CountByNonDeletedAsync();
            var ordersCountResult = await _orderService.CountAsync();
            var personelsCountResult = await _personService.CountAsync();
            var usersCount = await _userManager.Users.CountAsync();
            var ordersResult = await _orderService.GetAllAsync();
            if (categoriesCountResult.ResultStatus==ResultStatus.Success&&articlesCountResult.ResultStatus==ResultStatus.Success&&commentsCountResult.ResultStatus==ResultStatus.Success&&usersCount>-1&&ordersResult.ResultStatus==ResultStatus.Success)
            {
                return View(new DashboardViewModel
                {
                    CategoriesCount = categoriesCountResult.Data,
                    ArticlesCount = articlesCountResult.Data,
                    CommentsCount = commentsCountResult.Data,
                    PersonelsCount= personelsCountResult.Data,
                    OrdersCount = ordersCountResult.Data,
                    UsersCount = usersCount,
                    Orders = ordersResult.Data
                });
            }

            return NotFound();

        }
    }
}
