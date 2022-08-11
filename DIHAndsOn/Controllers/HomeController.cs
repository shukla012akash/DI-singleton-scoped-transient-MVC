using DIHAndsOn.Dependencies;
using DIHAndsOn.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DIHAndsOn.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DependencyService1 _dependencyService1;
        private readonly DependencyService2 _dependencyService2;

        public HomeController(ILogger<HomeController> logger,DependencyService1 dependencyService1, DependencyService2 dependencyService2)
        {
            _logger = logger;
            _dependencyService1 = dependencyService1;
            _dependencyService2 = dependencyService2;
        }

        public IActionResult Index()
        {
            _dependencyService1.Write();
            _dependencyService2.Write();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}