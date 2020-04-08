using CityInfo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Data
{
	public class CityDataStore
	{
		//static// can't be change, immutable
		public static CityDataStore Current { get; } = new CityDataStore();
		public List<CityDTO> Cities { get; set; }
		public CityDataStore()
		{
			Cities = new List<CityDTO>() {
				new CityDTO()
					{
						Id = 1,
						Name = "Pasig City",
						Description = "Business center in the North",
						PointOfInterests = new List<PointOfInterestDTO> {
							new PointOfInterestDTO {
								Id = 1,
								Name = "Ortigas Center",
								Description = "central business district located within the joint boundaries of Pasig, Mandaluyong and Quezon City"
							},
							new PointOfInterestDTO {
								Id = 2,
								Name = "Pasig River",
								Description = "The Pasig River is a river in the Philippines that connects Laguna de Bay to Manila Bay"
							}
						}
					},
				new CityDTO()
					{
						Id = 2,
						Name = "Makati City",
						Description = "Shopping capital",
						PointOfInterests = new List<PointOfInterestDTO> {
							new PointOfInterestDTO {
								Id = 3,
								Name = "Greenbelt",
								Description = "Greenbelt is a shopping mall located at Ayala Center"
							}
						}
					},
				new CityDTO()
					{
						Id = 3,
						Name = "Manila",
						Description = "Capital of the Philippines",
						PointOfInterests = new List<PointOfInterestDTO> {
							new PointOfInterestDTO {
								Id = 4,
								Name = "Divisoria",
								Description = "Cheap bargains"
							},
							new PointOfInterestDTO {
								Id = 5,
								Name = "Binondo",
								Description = "Chinese people"
							},
							new PointOfInterestDTO {
								Id = 6,
								Name = "Rizal Park",
								Description = "Park of Rizal"
							}
						}
					},
				new CityDTO() {
					Id = 4,
					Name = "Taguig",
					Description = "Business center east",
					PointOfInterests = new List<PointOfInterestDTO> {
						new PointOfInterestDTO {
							Id = 7,
							Name = "BGC",
							Description = "nice park"
						},
						new PointOfInterestDTO {
							Id = 8,
							Name = "Fort",
							Description = "expensive mall"
						}
					}
				}
			};

		}
	}
}
