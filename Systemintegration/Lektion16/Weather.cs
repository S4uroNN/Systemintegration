using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lektion16
{
    internal class Weather
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Temperature { get; set; }
        public string Clouds { get; set; }

        public Weather(string city, string country, string temperature, string clouds)
        {
            City = city;
            Country = country;
            Temperature = temperature;
            Clouds = clouds;
        }
    }
}
