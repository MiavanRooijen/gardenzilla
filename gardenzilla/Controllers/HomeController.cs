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
            // alle producten ophalen
            var festivals = GetAllFestivals();

            // de lijst met namen in de html stoppen
            return View(festivals);
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

        public Festival GetFestival(int id)
        {
            // product ophalen uit de database op basis van het id
            var rows = DatabaseConnector.GetRows($"select * from festival where id = {id}");

            // We krijgen altijd een lijst terug maar er zou altijd één product in moeten
            // zitten dus we pakken voor het gemak gewoon de eerste
            Festival festival = GetFestivalFromRow(rows[0]);

            // Als laatste sturen het product uit de lijst terug
            return festival;
        }

        public List<Festival> GetAllFestivals()
        {
            // alle producten ophalen
            var rows = DatabaseConnector.GetRows("select * from festival");

            // lijst maken om alle namen in te stoppen
            List<Festival> festivals = new List<Festival>();

            foreach (var row in rows)
            {
                // elke naam toevoegen aan de lijst met namen
                Festival f = GetFestivalFromRow(row);

                festivals.Add(f);
            }

            return festivals;

            // de lijst met namen in de html stoppen

        }


        private Festival GetFestivalFromRow(Dictionary<string, object> row)
        {
            Festival f = new Festival();
            f.Naam = row["naam"].ToString();
            f.Beschrijving = row["beschrijving"].ToString();
            f.Datum = DateTime.Parse(row["datum"].ToString());
            f.Id = Convert.ToInt32(row["id"]);

            return f;
        }

    }
}
