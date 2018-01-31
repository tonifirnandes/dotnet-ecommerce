using Microsoft.AspNetCore.Mvc;
using Qmall.Repositories;

namespace Qmall.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //HomeFitur();
            return View();
        }       
    }
}
