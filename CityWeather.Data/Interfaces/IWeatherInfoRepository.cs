
namespace CityWeather.Data.Interfaces
{
    public interface IWeatherInfoRepository
    {
        string GetWeather(string cityName, string countryCode);
    }
}
