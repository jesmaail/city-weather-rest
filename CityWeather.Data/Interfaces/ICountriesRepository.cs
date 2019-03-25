using CityWeather.Entities;

namespace CityWeather.Data.Interfaces
{
    public interface ICountriesRepository
    {
        CountryInfo GetCountryInformation(string name); 
    }
}
