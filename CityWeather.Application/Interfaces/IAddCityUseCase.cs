using CityWeather.Entities;

namespace CityWeather.Application.Interfaces
{
    public interface IAddCityUseCase
    {
        void Execute(CityDetails cityDetails);
    }
}
