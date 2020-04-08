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
    [Route("api/[controller]")]
    [ApiController]
    public class MayorController : ControllerBase
    {
        // GET: api/Mayor
        [HttpGet]
        public IActionResult GetMayors()
        {
            var mayors = MayorDataStore.Current.Mayors;
            return Ok(mayors);
        }

        // GET: api/Mayor/5
        [HttpGet("{mayorId}", Name = "GetMayor")]
        public IActionResult GetMayor(int mayorId)
        {
            var mayors = MayorDataStore.Current.Mayors.FirstOrDefault(m => m.Id == mayorId);
            if (mayors == null)
            {
                return NotFound();
            }
            return Ok(mayors);
        }

        // POST: api/Mayor
        [HttpPost]
        public IActionResult CreateMayor([FromBody] MayorDTO mayor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var mayorModel = MayorDataStore.Current.Mayors.FirstOrDefault(m => m.Name == mayor.Name);
            var mayors = MayorDataStore.Current.Mayors;

            var lastID = mayors.Max(m => m.Id);
            if (mayorModel == null)
            {
                var newMayor = new MayorDTO()
                {
                    Id = ++lastID,
                    Name = mayor.Name,
                    Age = mayor.Age
                };
                mayors.Add(newMayor);
                //return CreatedAtRoute("GetMayor", new { mayorId = newMayor.Id }, newMayor);
                return Ok();
            } else
            {
                return BadRequest();
            }
        }

        // PUT: api/Mayor/5
        [HttpPut("{id}")]
        public IActionResult UpdateMayor(int id, [FromBody] MayorDTO mayorUpdate)
        {
            var mayorModel = MayorDataStore.Current.Mayors.FirstOrDefault(m => m.Id == id);

            if (mayorModel == null)
                return NotFound();

            mayorModel.Name = mayorUpdate.Name;
            mayorModel.Age = mayorUpdate.Age;

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            var mayorModel = MayorDataStore.Current.Mayors.FirstOrDefault(m => m.Id == id);

            if (mayorModel == null)
                return NotFound();

            MayorDataStore.Current.Mayors.Remove(mayorModel);
            return NoContent();
        }
    }
}
