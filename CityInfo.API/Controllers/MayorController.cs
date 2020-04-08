using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Data;
using CityInfo.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace CityInfo.API.Controllers
{
    [Route("api/mayors")]
    [ApiController]
    public class MayorController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMayors()
        {
            var mayors = MayorDataStore.Current.Mayors;
            return Ok(mayors);
        }

        [HttpGet("{mayorId}", Name = "getMayor")]
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
		public IActionResult CreateMayor([FromBody] MayorDTO mayor)
		{
			var mayors = MayorDataStore.Current.Mayors;
			var existingMayor = mayors.FirstOrDefault(c => c.Name.ToLower().Equals(mayor.Name.ToLower()));

			if (existingMayor != null)
			{
				ModelState.AddModelError("Name", "Mayor Name must be Unique");
			}

			if(mayor.Age < 40)
			{
				ModelState.AddModelError("Age", "Mayor is Underage");
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var lastID = mayors.Max(c => c.Id);

			var newMayor = new MayorDTO()
			{
				Id = ++lastID,
				Name = mayor.Name,
				Age = mayor.Age
			};
			mayors.Add(newMayor);
			return CreatedAtRoute("GetMayor", new { mayorId = newMayor.Id }, newMayor);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateMayor(int id, [FromBody] MayorForUpdateDTO mayorUpdate)
		{
			var mayor = MayorDataStore.Current.Mayors.FirstOrDefault(c => c.Id == id);

			if (mayor == null)
				return NotFound();

			if(mayorUpdate.Age < 40)
			{
				 ModelState.AddModelError("Age", "Mayor is Underage");
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			mayor.Name = mayorUpdate.Name;
			mayor.Age = mayorUpdate.Age;

			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteMayor(int id)
		{
			var mayor = MayorDataStore.Current.Mayors.FirstOrDefault(c => c.Id == id);

			if (mayor == null)
				return NotFound();

			MayorDataStore.Current.Mayors.Remove(mayor);
			return NoContent();
		}
	}
}