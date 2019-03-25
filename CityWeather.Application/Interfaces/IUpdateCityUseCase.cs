using CityWeather.Entities;

namespace CityWeather.Application.Interfaces
{
    public interface IUpdateCityUseCase
    {
        void Execute(int id, CityDetails cityDetails);
    }
}
