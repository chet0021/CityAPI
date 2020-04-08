using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
    public class MayorDTO
    {
        public int Id { get; set; } = 0;
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
