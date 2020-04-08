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
    [Route("api/mayors")]
    [ApiController]
    public class MayorsController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetMayors()
        {
            var cities = MayorDataStore.Current.Mayors;
            return Ok(cities);
        }

        [HttpGet("{mayorId}")]
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
        public IActionResult CreateMayor([FromBody] Mayors mayor)
        {
            var mayors = MayorDataStore.Current.Mayors;
            var existing = mayors.FirstOrDefault(c => c.Name.ToLower().Equals(mayor.Name.ToLower()));

            if(existing != null)
            {
                ModelState.AddModelError("Name", "Mayor name must be unique.");
            }
            if(mayor.Age < 40)
            {
                ModelState.AddModelError("Age", "Mayor is underaged");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lastID = mayors.Max(c => c.Id);

            var newMayor = new Mayors()
            {
                Id = ++lastID,
                Name = mayor.Name,
                Age = mayor.Age
            };
            mayors.Add(newMayor);
            return CreatedAtRoute("GetMayor", new { mayorId = newMayor.Id }, newMayor);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCity(int id, [FromBody] Mayors mayorUpdate)
        {
            var mayor = MayorDataStore.Current.Mayors.FirstOrDefault(c => c.Id == id);

            if (mayor == null)
                return NotFound();

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