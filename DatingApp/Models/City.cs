using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.Models
{
    public class City
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CityName { get; set; }
    }
}
