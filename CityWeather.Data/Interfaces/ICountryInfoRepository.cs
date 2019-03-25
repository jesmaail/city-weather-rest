using CityWeather.Entities;

namespace CityWeather.Data.Interfaces
{
    public interface ICountryInfoRepository
    {
        CountryInfo GetCountryInformation(string name); 
    }
}
