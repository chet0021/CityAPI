using System;
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
	[Route("api/mayors")]
	public class MayorController : ControllerBase
    {

			[HttpGet]
			public IActionResult GetMayors()
			{
				var mayors = MayorDataStore.Current.Mayors;
				return Ok(mayors);
			}
			[HttpGet("{mayorId}", Name="GetMayor")]
			public IActionResult GetMayor(int mayorId)
		{
			var mayor = MayorDataStore.Current.Mayors.FirstOrDefault(c => c.Id == mayorId);
			if (mayor == null)
				return NotFound();

			return Ok(mayor);
			//return mayor == null ? NotFound() : Ok(mayor);
		}

		[HttpPost]
		public IActionResult CreateMayor([FromBody] Mayor mayor)
		{
			var mayors = MayorDataStore.Current.Mayors;
			var existing = mayors.Any(c => c.Name == mayor.Name);
			if (mayor.Age<40 ||existing)
			{
				return BadRequest(ModelState);
			}
			var lastId = mayors.Max(c => c.Id);
			var newMayor = new Mayor()
			{ Id = ++lastId,
			Name=mayor.Name,
			Age=mayor.Age,
			Nickname=mayor.Nickname };

			mayors.Add(newMayor);
			return CreatedAtRoute("GetMayor", new { mayorId = mayor.Id }, newMayor);
		}


		[HttpPut("{id}")]
		public IActionResult UpdateMayor(int id, [FromBody] MayorForUpdate mayorUpdate)
		{
			var mayorModel = MayorDataStore.Current.Mayors.FirstOrDefault(c => c.Id == id);

			if (mayorModel == null)
				return NotFound();

			mayorModel.Name = mayorModel.Name;
			mayorModel.Age = mayorModel.Age;
			mayorModel.Nickname = mayorModel.Nickname;

			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteMayor(int id)
		{
			var mayorModel = MayorDataStore.Current.Mayors.FirstOrDefault(c => c.Id == id);

			if (mayorModel == null)
				return NotFound();

			MayorDataStore.Current.Mayors.Remove(mayorModel);
			return NoContent();
		}

	}

	}
