using CityWeather.Entities;
using System.Collections.Generic;

namespace CityWeather.Application.Interfaces
{
    public interface ISearchCityUseCase
    {
        IEnumerable<CityDetails> Execute(string name);
    }
}
