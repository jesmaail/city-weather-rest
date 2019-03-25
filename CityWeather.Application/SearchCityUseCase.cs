using CityWeather.Application.Interfaces;
using CityWeather.Data.Interfaces;
using CityWeather.Entities;
using System.Collections.Generic;

namespace CityWeather.Application
{
    public class SearchCityUseCase : ISearchCityUseCase
    {
        private readonly ICitiesRepository _citiesRepository;

        public SearchCityUseCase(ICitiesRepository citiesRepository)
        {
            _citiesRepository = citiesRepository;
        }

        public IEnumerable<CityDetails> Execute(string name)
        {
            return _citiesRepository.GetCityDetails(name);
        }
    }
}
