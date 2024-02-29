using System.ComponentModel.DataAnnotations;

namespace DatingApp.Models
{
    public class Like
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a valid sender Id")]
        public int SenderId { get; set; }

        [Required(ErrorMessage = "Please provide a valid receiver Id")]
        public int ReceiverId { get; set; }
        public int Status { get; set; } = 0;

        public virtual UserProfile Sender { get; set; } = null!;
        public virtual UserProfile Receiver { get; set; } = null!;

    }
}
