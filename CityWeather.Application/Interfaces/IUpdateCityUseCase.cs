using System;

namespace CityWeather.Application.Interfaces
{
    public interface IUpdateCityUseCase
    {
        void Execute(int id, int rating, DateTime established, int estimatedPopulation);
    }
}
