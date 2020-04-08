using System;
using System.Collections.Generic;
using System.Linq;
using CityInfo.API.Models;
using System.Threading.Tasks;

namespace CityInfo.API.Data
{
    public class MayorDataStore
    {
		public static MayorDataStore Current { get; } = new MayorDataStore();
		public List<Mayor> Mayors { get; set; }

		public MayorDataStore()
		{
			Mayors = new List<Mayor>() {
				new Mayor()
					{
						Id=1,
						Name="Isko Moreno",
						Age=40,
						Nickname="Yorme"
				},
				new Mayor()
					{
						Id = 2,
						Name = "Marcelino Teodoro",
						Age=50,
						Nickname = "March",
						
					},
				new Mayor()
					{
						Id = 3,
						Name = "Vico Sotto",
						Age=420,
						Nickname="Vivico"
						
					},
				new Mayor() {
					Id = 4,
					Name = "Joy Belmonte",
					Age=69,
					Nickname="No Joy"
				}
			};

		}
	}

}
