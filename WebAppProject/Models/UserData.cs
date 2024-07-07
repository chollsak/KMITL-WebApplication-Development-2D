using System.ComponentModel.DataAnnotations;

namespace WebAppProject.Models
{
    public class UserData
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string Image { get; set; } = "https://www.planetware.com/wpimages/2020/02/france-in-pictures-beautiful-places-to-photograph-eiffel-tower.jpg";
        public string about { get; set; } = "Hello World!!";
        public UserData() { 
            Id = Guid.NewGuid();
        }
    }
}
