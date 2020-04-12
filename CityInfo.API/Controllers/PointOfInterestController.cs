using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Data;
using CityInfo.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
	[ApiController]
	[Route("api/cities/{cityId}/pointOfInterest")]
	public class PointOfInterestController : ControllerBase
	{
		
		[HttpGet(Name = "GetPointOfInterestsByCityID")]
		public IActionResult GetPointOfInterestsByCityID(int cityId)
		{
			var city = CityDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

			if (city == null)
				return NotFound();

			return Ok(city.PointOfInterests);
		}

		[HttpGet("{id}", Name = "GetPointOfInterest")]
		public IActionResult GetPointOfInterest(int cityId, int id)
		{
			var city = CityDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

			if (city == null)
				return NotFound();

			var pointOfInterest = city.PointOfInterests.FirstOrDefault(c => c.Id == id);

			if (pointOfInterest == null)
				return NotFound();

			return Ok(pointOfInterest);
		}

		[HttpPost]
		public IActionResult CreatePointOfInterest(int cityId, [FromBody] PointOfInterestDTO pointOfInterest)
		{
			var city = CityDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
			if (city == null)
				return NotFound();

			var lastID = CityDataStore.Current.Cities.SelectMany(c => c.PointOfInterests).Max(c => c.Id);
			var newPointOfInterest = new PointOfInterestDTO
			{
				Id = ++lastID,
				Name = pointOfInterest.Name,
				Description = pointOfInterest.Description
			};
			city.PointOfInterests.Add(newPointOfInterest);

			return CreatedAtRoute("GetPointOfInterest",
				new { cityId = cityId, id = newPointOfInterest.Id },
				newPointOfInterest);
		}

	}
}