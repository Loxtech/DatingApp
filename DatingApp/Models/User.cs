using System.ComponentModel.DataAnnotations;

namespace DatingApp.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a first name")]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide a last name")]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide an email")]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide a login")]
        [StringLength(100)]
        public string Login { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide a password")]
        [StringLength(100)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide a password2")]
        [StringLength(100)]
        public string Password2 { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        [Required(ErrorMessage ="Please provide a valid user profile")]
        public UserProfile userProfile { get; set; }
    }
}
