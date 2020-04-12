using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models
{
    public class MayorDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Mayor name is required")]
        public string MayorName { get; set; }
        public int Age { get; set; }
    }
}
