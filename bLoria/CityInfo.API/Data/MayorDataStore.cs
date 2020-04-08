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
        public List<Mayors> Mayors { get; set; }
        public MayorDataStore()
        {
            Mayors = new List<Mayors>()
            {
                new Mayors()
                {
                    Id = 1,
                    Name = "Vico Sotto",
                    Age = 30,
                },

                new Mayors()
                {
                    Id = 2,
                    Name = "Abigail Binay",
                    Age = 44,
                },

                new Mayors()
                {
                    Id = 3,
                    Name = "Isko Moreno",
                    Age = 45,
                }
            };
        }
    }
}
