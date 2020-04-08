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
						Name = "Francisco Moreno Domagoso",
						Nickname = "Isko",
						Age = 45,
						Education ="Pamantasan ng Lungsod ng Maynila"

					},
				new MayorDTO()
					{ 
						Id = 2,
						Name = "Maria Josefina Tanya Belmonte Alimurung",
						Nickname = "Joy",
						Age = 50,
						Education ="Ateneo de Manila University"

					}
			};

		}
	}
}
