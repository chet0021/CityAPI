using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Models
{
    public class CityMayor
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(200)]
        public string MayorName { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(40, 100, ErrorMessage = "Underage being a mayor")]
        public int Age { get; set; }
    }
}
