using System.ComponentModel.DataAnnotations;
namespace gardenzilla.Models
{ 
public class Person
{
    [Required ]
    public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Description { get; set; }
}
}
