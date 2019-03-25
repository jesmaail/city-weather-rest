using CityWeather.Entities;

namespace CityWeather.Data
{
    public interface ICountriesRepository
    {
        CountryInfo GetCountryInformation(string name); 
    }
}
