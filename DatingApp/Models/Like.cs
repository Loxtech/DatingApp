using System.ComponentModel.DataAnnotations;

namespace DatingApp.Models
{
    public class Like
    {
        public int Id { get; set; } 

        //[Required(ErrorMessage = "Please provide a valid liker Id")]
        //public int LikerId { get; set; }

        //[Required(ErrorMessage = "Please provide a valid likee Id")]
        //public int LikeeId { get; set; }

        [Range(0, 2)]
        public int Status { get; set; } = 0;

        //public virtual UserProfile Liker { get; set; } = null!;
        //public virtual UserProfile Likee { get; set; } = null!;
    }
}
