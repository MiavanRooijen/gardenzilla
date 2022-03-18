using gardenzilla.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace gardenzilla.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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

        public IActionResult ShowAll()
        {
            return View();
        }

        [Route("Contact")]
        public IActionResult Contact( Person person)
        {
            
            return View(person);
        }

        [Route("terrein")]
        public IActionResult Terrein()
        {
           
            return View();
        }

        [Route("gallerij")]
        public IActionResult Gallerij()
        {
            
            return View();
        }

        [Route("festivals")]
        public IActionResult Festivals()
        {
            
            return View();
        }
    }
}
