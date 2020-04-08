using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class Mayor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";
        [Range(35, 40)]
        public int Age { get; set; } = 0;
    }
}
