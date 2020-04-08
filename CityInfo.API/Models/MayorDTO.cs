using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CityInfo.API.Models
{
    public class MayorDTO
    {

		public int Id { get; set; }

		[Required(ErrorMessage = "Name is required")]
		[MaxLength(50)]
		public string Name { get; set; }

		public string Nickname { get; set; }

		[Required(ErrorMessage = "Age is required")]
		[Range(40, 70)]
		public int Age { get; set; }

		public string Education { get; set; }

		//Returning child resources: 
	}
}

