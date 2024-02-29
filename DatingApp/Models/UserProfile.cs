﻿using System.ComponentModel.DataAnnotations;

namespace DatingApp.Models
{
    public class UserProfile
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a username")]
        [StringLength(100)]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide date of birth")]
        public DateTime Birthday { get; set; }

        [Range(50, 300)]
        public int HeightCM { get; set; }

        [Range(10, 500)]
        public int WeightKG { get; set; }
        public string? AboutMe { get; set; }

        [Required(ErrorMessage = "Please provvide a valid city code")]
        public int CityId { get; set; }
        public int GenderId { get; set; }

        [Required(ErrorMessage = "Please provvide a valid user Id")]
        public int UserId { get; set; }
    }
}