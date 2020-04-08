using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CityInfo.API.Data;
using CityInfo.API.Models;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/mayors")]
    [ApiController]
    public class CityMayorController : ControllerBase
    {
        //api/cities/mayors
        [HttpGet(Name = "GetMayors")]
        public IActionResult GetMayors()
        {

            var mayors = CityMayorSource.currentMayor.Mayors;
            return Ok(mayors);
        }

       //api/cities/mayors
       [HttpPost]
       public IActionResult AddMayors(CityMayor mayor)
       {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mayorModel = CityMayorSource.currentMayor.Mayors.FirstOrDefault(item => item.MayorName.ToLower() == mayor.MayorName.ToLower());
            
            if (mayorModel != null)
            {
                return Content($"Mayor {mayor.MayorName} is already on the list");
            }

            var mayors = CityMayorSource.currentMayor.Mayors;

            var newMayor = new CityMayor()
            {
                MayorName = mayor.MayorName,
                Age = mayor.Age
            };
            mayors.Add(newMayor);
            return CreatedAtRoute("GetMayors", newMayor);
        }
        ///breakpoint
        //api/cities/mayors/{mayorName}
        [HttpPut("{mayorName}")]
        public IActionResult UpdateMayor(string mayorName, CityMayor mayor)
        {
            var mayorModel = CityMayorSource.currentMayor.Mayors.FirstOrDefault(item => item.MayorName.ToLower() == mayorName.ToLower());

            if (mayorModel == null)
                return NotFound();

            mayorModel.MayorName = mayor.MayorName;
            mayorModel.Age = mayor.Age;

            return NoContent();
        }

        //api/cities/mayors/{mayorName}
        [HttpDelete("{mayorName}")]
        public IActionResult DeleteMayor(string mayorName)
        {
            var mayorModel = CityMayorSource.currentMayor.Mayors.FirstOrDefault(item => item.MayorName.ToLower() == mayorName.ToLower());

            if (mayorModel == null)
                return NotFound();

            CityMayorSource.currentMayor.Mayors.Remove(mayorModel);
            return NoContent();
        }
    }
}