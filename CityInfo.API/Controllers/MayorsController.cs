using CityInfo.API.Data;
using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
	[ApiController]
	[Route("api/mayors")]
	public class MayorsController : ControllerBase
	{
		[HttpGet]
		public IActionResult GetMayors()
		{
			var mayors = MayorDataStore.Current.Mayors;
			return Ok(mayors);
		}

		[HttpGet("{mayorId}", Name = "GetMayors")]
		public IActionResult GetMayor(int mayorId)
		{
			var mayor = MayorDataStore.Current.Mayors.FirstOrDefault(c => c.Id == mayorId);

			if (mayor == null)
			{
				return NotFound();
			}

			return Ok(mayor);
		}

		[HttpPost]
		public IActionResult AddMayor([FromBody] MayorDTO mayor)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var mayors = MayorDataStore.Current.Mayors;
			var lastID = mayors.Max(c => c.Id);
			var checkExist = MayorDataStore.Current.Mayors.FirstOrDefault(c => c.Name == mayor.Name);

			if (checkExist == null)
			{
				var newMayor = new MayorDTO()
				{
					Id = ++lastID,
					Name = mayor.Name,
					Nickname = mayor.Nickname,
					Age = mayor.Age,
					Education = mayor.Education
				};
				mayors.Add(newMayor);
				return CreatedAtRoute("GetCity", new { cityId = newMayor.Id }, newMayor);
			}
			return BadRequest();
		}

		[HttpPut("{id}")]
		public IActionResult UpdateMayor(int id, [FromBody] MayorForUpdatedDTO mayorUpdate)
		{
			var mayorModel = MayorDataStore.Current.Mayors.FirstOrDefault(c => c.Id == id);

			if (mayorModel == null)
			{
				return NotFound();
			}
			mayorModel.Name = mayorUpdate.Name;
			mayorModel.Nickname = mayorUpdate.Nickname;
			mayorModel.Age = mayorUpdate.Age;
			mayorModel.Education = mayorUpdate.Education;

			return NoContent();
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteMayor(int id)
		{
			var mayorMdl = MayorDataStore.Current.Mayors.FirstOrDefault(c => c.Id == id);

			if (mayorMdl == null)
			{
				return NotFound();
			}

			MayorDataStore.Current.Mayors.Remove(mayorMdl);
			return NoContent();
		}

	}
}
