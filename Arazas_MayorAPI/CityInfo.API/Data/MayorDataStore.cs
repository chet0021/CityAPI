using CityInfo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Data
{
    public class MayorDataStore
    {
        public static MayorDataStore Current { get; } = new MayorDataStore();

        public List<MayorDTO> Mayors { get; set; }

        public MayorDataStore()
        {
            Mayors = new List<MayorDTO>()
            {
                new MayorDTO { Id = 1, Name = "Vico Sotto", Age = 31 },
                new MayorDTO { Id = 2, Name = "Isko Moreno", Age = 45 },
                new MayorDTO { Id = 3, Name = "Joy Belmonte", Age = 35 },
                new MayorDTO { Id = 4, Name = "Sherwin Gatchallian", Age = 39 },
                new MayorDTO { Id = 5, Name = "Oscar Malapitan", Age = 48 }
            };
        }
    }
}
