﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Data;
using CityInfo.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
	[ApiController]
	[Route("api/cities")]
	public class CitiesController : ControllerBase
	{
		//CityDataStore cityDataStore = new CityDataStore();

		[HttpGet]
		public IActionResult GetCities()
		{
			var cities = CityDataStore.Current.Cities;
			return Ok(cities);
		}
		
		[HttpGet("{cityId}", Name = "GetCity")]
		public IActionResult GetCity(int cityId)
		{
			var city = CityDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
			if (city == null)
			{
				return NotFound();
			}
			return Ok(city);
		}

		[HttpPost]
		public IActionResult CreateCity([FromBody] CityDTO city)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var cities = CityDataStore.Current.Cities;

			var lastID = cities.Max(c => c.Id);

			var newCity = new CityDTO()
			{
				Id = ++lastID,
				Name = city.Name,
				Description = city.Description
			};
			cities.Add(newCity);
			return CreatedAtRoute("GetCity", new { cityId = newCity.Id }, newCity);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateCity(int id, [FromBody] CityForUpdateDTO cityUpdate)
		{
			var cityModel = CityDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);

			if (cityModel == null)
				return NotFound();

			cityModel.Name = cityUpdate.Name;
			cityModel.Description = cityUpdate.Description;

			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteCity(int id)
		{
			var cityModel = CityDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);

			if (cityModel == null)
				return NotFound();

			CityDataStore.Current.Cities.Remove(cityModel);
			return NoContent();
		}

	}
}