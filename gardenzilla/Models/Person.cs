
using System;
using System.ComponentModel.DataAnnotations;

namespace gardenzilla.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Voornaam is een verplicht veld")]
        [Display(Name = "Voornaam")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Achternaam is een verplicht veld")]
         [Display(Name = "Achternaam")]
        public string LastName { get; set; }
       
        [Required(ErrorMessage = "Emailadres is een verplicht veld")]
        [EmailAddress(ErrorMessage = "Geen geldig email adres")]
        
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Telefoon is een verplicht veld")]
        [Display(Name = "Telefoon")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Adres is een verplicht veld")]
        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Bericht is een verplicht veld")]
        [Display(Name = "Bericht")]
        public string Description { get; set; }
        
    }
 
}

namespace gardenzilla.Database
{
    public class Festival
    {
        public int Id { get; set; }
        public string? Naam { get; set; }
        public string Beschrijving { get; set; }
        public DateTime Datum { get; set; }
    }
}
