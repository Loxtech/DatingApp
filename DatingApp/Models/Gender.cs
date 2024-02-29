using System.ComponentModel.DataAnnotations;

namespace DatingApp.Models
{
    public class Gender
    {
        public Gender()
        {
            UserProfile = new List<UserProfile>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a Gender")]
        [StringLength(10)]
        public string GenderName { get; set; } = null!;

        public List<UserProfile> UserProfile { get; set; }
    }
}
