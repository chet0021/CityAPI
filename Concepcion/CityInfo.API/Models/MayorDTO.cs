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

		[Required(ErrorMessage = "Name is required")]
		[MaxLength(50)]
		public string Name { get; set; }

		[Required(ErrorMessage = "Age is required")]
		public int Age { get; set; }
	}
}
