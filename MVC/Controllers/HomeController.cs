using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;
using WebAPI.Repositories;
using WebAPI.Services;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IDutyRepository repository, IDutyService service, IMapper mapper)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List", "Duty");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}