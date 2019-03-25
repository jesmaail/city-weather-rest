using CityWeather.Entities;
using System.Collections.Generic;

namespace CityWeather.Data.Interfaces
{
    public interface ICitiesRepository
    {
        void StoreCityDetails(CityDetails city);

        IEnumerable<CityDetails> GetCityDetails(string name);

        void UpdateCityDetails(int id, CityDetails city);

        void DeleteCityDetails(int id);
    }
}
