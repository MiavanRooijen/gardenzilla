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
            // alle producten ophalen
            var products = GetAllProducts();

            // de lijst met namen in de html stoppen
            return View(products);
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

        [Route("product/{id}")]
        public IActionResult ProductDetails(int id)
        {
            var products = GetProduct(id);
            return View(products);
        }

        private Product GetProduct(int id)
        {
            // alle producten ophalen
            var rows = DatabaseConnector.GetRows($"select * from product where id = {id}");

            // lijst maken om alle namen in te stoppen
            List<Product> products = new List<Product>();

            foreach (var row in rows)
            {
                Product product = GetProductFromRow(rows[0]);
            }

            return products[0];
        }

        public List<Product> GetAllProducts()
        {
            // alle producten ophalen
            var rows = DatabaseConnector.GetRows("select * from product");

            // lijst maken om alle namen in te stoppen
            List<Product> products = new List<Product>();

            foreach (var row in rows)
            {
                // elke naam toevoegen aan de lijst met namen
                Product p = GetProductFromRow(row);

                products.Add(p);
            }

            return products;

            // de lijst met namen in de html stoppen

        }


        private Product GetProductFromRow(Dictionary<string, object> row)
        {
            Product p = new Product();
            p.Naam = row["naam"].ToString();
            p.Prijs = row["prijs"].ToString();
            p.Beschikbaarheid = Convert.ToInt32(row["beschikbaarheid"]);
            p.Id = Convert.ToInt32(row["id"]);

            return p;
        }

    }
}
