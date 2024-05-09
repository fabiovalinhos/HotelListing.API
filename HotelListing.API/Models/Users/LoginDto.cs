using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Models.Users
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Sua senha é limitado de {2} até {1}", MinimumLength = 6)]
        public string Password { get; set; }
    }
}