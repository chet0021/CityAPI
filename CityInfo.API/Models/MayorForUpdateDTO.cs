using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models
{
    public class MayorForUpdateDTO
    {
        public int Id { get; set; }
        public string MayorName { get; set; }
        public int Age { get; set; }
    }
}
