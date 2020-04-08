using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Models;

namespace CityInfo.API.Data
{
    public class CityMayorSource
    {
        public static CityMayorSource currentMayor { get; } = new CityMayorSource();
        public List<CityMayor> Mayors { get; set; }

        public CityMayorSource()
        {
            Mayors = new List<CityMayor>()
            {
                new CityMayor()
                {
                    MayorName = "John Doe",
                    Age = 42,
                },
                new CityMayor()
                {
                    MayorName = "Ervin Night",
                    Age = 47,
                },
                new CityMayor()
                {
                    MayorName = "Charles Cruz",
                    Age = 53,
                }
            };
        }
    }
}
