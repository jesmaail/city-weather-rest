using CityWeather.Entities;
using System;
using System.Collections.Generic;

namespace CityWeather.Data.Interfaces
{
    public interface ICitiesRepository
    {
        void StoreCityDetails(CityDetails city);

        IEnumerable<CityDetails> GetCityDetails(string name);

        void UpdateCityDetails(int id, int rating, DateTime established, int estimatedPopulation);

        void DeleteCityDetails(int id);
    }
}
