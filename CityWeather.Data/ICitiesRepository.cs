using CityWeather.Entities;

namespace CityWeather.Data
{
    public interface ICitiesRepository
    {
        void StoreCityDetails(CityDetails city);

        CityDetails GetCityDetails(int id);

        void UpdateCityDetails(int id, CityDetails city);

        void DeleteCityDetails(int id);
    }
}
