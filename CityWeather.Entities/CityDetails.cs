using System;

namespace CityWeather.Entities
{
    public class CityDetails
    {
        public string Name { get; set; }

        public string State { get; set; }

        public string CountryName { get; set; }

        public CountryInfo CountryInfo { get; set; }

        public int Rating { get; set; }

        public DateTime Established { get; set; }

        public int EstimatedPopulation { get; set; }
    }
}
