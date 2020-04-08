using CityInfo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Data
{
	public class MayorDataStore
	{
		//static// can't be change, immutable
		public static MayorDataStore Current { get; } = new MayorDataStore();
		public List<MayorDTO> Mayors { get; set; }
		public MayorDataStore()
		{
			Mayors = new List<MayorDTO>() {
				new MayorDTO()
					{
						Id = 1,
						Name = "Mayor Isko Moreno",
						Age = 45
					},
				new MayorDTO()
					{
						Id = 2,
						Name = "Vico Sotto",
						Age = 50
					}
			};

		}
	}
}
