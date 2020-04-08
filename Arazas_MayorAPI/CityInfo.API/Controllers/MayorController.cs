using CityInfo.API.Data;
using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MayorController : ControllerBase
    {
        

        [HttpGet]
        public IActionResult GetMayors()
        {
            var mayors = MayorDataStore.Current.Mayors;

            return Ok(mayors);
        }

        [HttpGet("{id}")]
        public IActionResult GetMayor(int id)
        {
            var mayor = MayorDataStore.Current.Mayors.Where(m => m.Id == id).First();

            if (mayor == null) return NotFound();

            return Ok(mayor);
        }

        [HttpPost]
        public IActionResult CreateMayor([FromBody] MayorDTO mayor)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var mayors = MayorDataStore.Current.Mayors;

            var lastId = mayors.Max(m => m.Id);

            var newMayor = new MayorDTO { Id = ++lastId, Name = mayor.Name, Age = mayor.Age };

            mayors.Add(newMayor);

            return CreatedAtRoute("GetMayor", new { mayorId = newMayor.Id }, newMayor);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMayor(int id, [FromBody] MayorDTO mayorUpdate)
        {
            var mayorModel = MayorDataStore.Current.Mayors.FirstOrDefault(m => m.Id == id);

            mayorModel.Name = mayorUpdate.Name;
            mayorModel.Age = mayorUpdate.Age;



            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMayor(int id)
        {
            var mayorModel = MayorDataStore.Current.Mayors.FirstOrDefault(m => m.Id == id);

            if (mayorModel == null) return NotFound();

            MayorDataStore.Current.Mayors.Remove(mayorModel);

            return NoContent();
        }
    }
}
