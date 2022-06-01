using gardenzilla.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using gardenzilla.Database;
using System;

namespace gardenzilla.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public List<Festival> GetAllFestivals ()
        {
            // alle producten ophalen
            var rows = DatabaseConnector.GetRows("select * from product");

            // lijst maken om alle namen in te stoppen
            List<Festival> festivals = new List<festival>();

            foreach (var row in rows)
            {
                // elke naam toevoegen aan de lijst met namen
                Festival f = new Festival();
                f.Naam = row["naam"].ToString();
                f.Prijs = row["prijs"].ToString();
                f.Beschikbaarheid = Convert.ToInt32(row["beschikbaarheid"]);
                f.id = Convert.ToInt32(row["id"]);

                Festival.Add(f);
            }

            return festivals;

            // de lijst met namen in de html stoppen
            
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

        [Route("contact")]
        public IActionResult contact()
        {
            return View();
        }

        [HttpPost]
        [Route("contact")]
        public IActionResult contact( Person person)
        {
            if (ModelState.IsValid)
                return Redirect("/succes");
            
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

        [Route("succes")]
        public IActionResult Succes()
        {
            return View();
        }

        [Route("festival/{id}")]
        public IActionResult FestivalDetails(int id)
        {
            var festival = GetFestival(id);
            return View(festival);
        }


        public IActionResult Index()
        {
            var festivals = GetAllFestivals();
            // alle producten ophalen
            var rows = DatabaseConnector.GetRows("select * from product");

            // lijst maken om alle namen in te stoppen
            List<string> names = new List<string>();

            foreach (var row in rows)
            {
                // elke naam toevoegen aan de lijst met namen
                names.Add(row["naam"].ToString());
            }

            // de lijst met namen in de html stoppen
            return View(festivals);
        }
    }
}
