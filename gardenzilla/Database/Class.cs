using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;






namespace gardenzilla.Database
{
    public class Product
    {
        public int Id { get; set; }
        public string? Naam { get; set; }
        public string? Prijs { get; set; }
        public int Beschikbaarheid { get; set; }

    }
}
