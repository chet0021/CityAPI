using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
    public class Mayor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Nickname { get; set; }
    }
}
