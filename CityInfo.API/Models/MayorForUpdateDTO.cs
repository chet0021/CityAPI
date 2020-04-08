using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models
{
	public class MayorForUpdatedDTO
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Nickname { get; set; }

		public int Age { get; set; }

		public string Education { get; set; }
	}
}
