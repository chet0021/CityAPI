using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CityInfo.API.Models;

namespace CityInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MayorController : ControllerBase
    {
        public List<Mayor> _oMayors = new List<Mayor>() {
            new Mayor()
            {
                Id = 1,
                Name="Vico",
                Age = 35

            },
             new Mayor()
            {
                Id = 2,
                Name="soto",
                Age = 45

            },
              new Mayor()
            {
                Id = 3,
                Name="isko",
                Age = 40

            }
        };
        /*    [HttpGet]
            public IActionResult Gets()
            {
                if (_oMayors.Count == 0)
                {
                    return NotFound("No list found.");
                }
                return Ok(_oMayors);
            }*/
        [HttpGet]
        public IActionResult Get(int id)
        {
            var oMayor = _oMayors.SingleOrDefault(x => x.Id == id);
            if (oMayor == null)
            {
                return NotFound("No Mayor found.");
            }
            return Ok(oMayor);
        }
        [HttpPost]
        public IActionResult Save(Mayor oMayor)
        {
            _oMayors.Add(oMayor);
            if (_oMayors.Count == 0)
            {
                return NotFound("No list found");
            }
            return Ok(oMayor);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMayor(int id)
        {
            var oMayor = _oMayors.SingleOrDefault(x => x.Id == id);
            if (oMayor == null)
            {
                return NotFound("No student found");
            }
            _oMayors.Remove(oMayor);
            if (_oMayors.Count == 0)
            {
                return NotFound("No List found");
            }
            return Ok(_oMayors);
        }
    }
}