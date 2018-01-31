
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Qmall.Repositories;
using Qmall.Areas.MainNavigation.ViewModels;
using Qmall.Models;
using System.Collections.Generic;
using Qmall.Areas.Newsletter.ViewModels;

namespace Qmall.Areas.Newsletter.Controllers
{
    [Area("Newsletter")]
    public class HomeController : Controller
    {
        private readonly INewsletterRepository NewsletterRepository;
        public HomeController(INewsletterRepository newsletterRepository)
        {
            NewsletterRepository = newsletterRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            NewsletterModel newsletterModel = await NewsletterRepository.GetAsync();
            List<ObjectNewsletter> newsletterList = new List<ObjectNewsletter>(newsletterModel.data.Capacity);
            newsletterList.AddRange(newsletterModel.data);
            return PartialView(new NewsletterViewModel(newsletterList));
        }
    }
}