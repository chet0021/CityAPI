using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models
{
	public class CityDTO
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Name is required")]
		[MaxLength(50)]
		public string Name { get; set; }

		[MaxLength(200)]
		public string Description { get; set; }

		//Returning child resources: 
		public ICollection<PointOfInterestDTO> PointOfInterests { get; set; } = new List<PointOfInterestDTO>();
	}
}
