using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Qmall.Areas.Login.Models;
using Qmall.Areas.TopNavigation.Models;
using Qmall.Extensions;

namespace Qmall.Areas.TopNavigation.Controllers
{
    [Area("TopNavigation")]
    public class TopNavigationController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return PartialView(new TopNavigationViewModel(await GetUserLoginSession()));
        }

        private async Task<LoginComponent> GetUserLoginSession()
        {
            return await Task.FromResult(
                HttpContext.Session.GetObject<LoginComponent>(SessionExtensionsMethods.USER_LOGIN_SESSION_KEY));
        }
    }
}