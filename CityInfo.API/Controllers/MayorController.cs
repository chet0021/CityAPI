using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Data;
using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/mayor")]
    public class MayorController : Controller
    {
        [HttpGet]
        public IActionResult GetMayors()
        {
            var mayor = CityDataStore.Current.Mayors;
            return Ok(mayor);
        }

        [HttpGet("{id}", Name = "GetMayorById")]
        public IActionResult GetMayorById(int id)
        {
            var mayor = CityDataStore.Current.Mayors.FirstOrDefault(c => c.Id == id);
            if (mayor == null)
            {
                return NotFound();
            }
            return Ok(mayor);
        }

        [HttpPost]
        public IActionResult CreateMayor([FromBody] MayorDTO mayor)
        {
            var mayors = CityDataStore.Current.Mayors;
            var existingMayor = mayors.FirstOrDefault(c => c.MayorName.ToLower().Equals(mayor.MayorName.ToLower()));
            var mayorAge = mayor.Age;

            if (existingMayor != null)
            {
                ModelState.AddModelError("MayorName", "Mayor name must be unique");
            }

            if (mayorAge < 40)
            {
                ModelState.AddModelError("Age", "Underage being a mayor");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lastId = mayors.Max(c => c.Id);
            var newMayor = new MayorDTO()
            {
                Id = ++lastId,
                MayorName = mayor.MayorName,
                Age = mayor.Age
            };
            mayors.Add(newMayor);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMayor(int id, [FromBody] MayorForUpdateDTO mayorUpdate)
        {
            var mayorModel = CityDataStore.Current.Mayors.FirstOrDefault(c => c.Id == id);

            if (mayorModel == null)
            {
                return NotFound();
            }
            else
            {
                mayorModel.MayorName = mayorUpdate.MayorName;
                mayorModel.Age = mayorUpdate.Age;
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMayor(int id)
        {
            var mayorModel = CityDataStore.Current.Mayors.FirstOrDefault(c => c.Id == id);

            if (mayorModel == null)
            {
                return NotFound();
            }
            else
            {
                CityDataStore.Current.Mayors.Remove(mayorModel);
                return NoContent();
            }
        }
    }
}

