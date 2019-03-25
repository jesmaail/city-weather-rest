using CityWeather.Data;
using CityWeather.Entities;
using System.Collections.Generic;

namespace CityWeather.Application
{
    public class SearchCityUseCase
    {
        private readonly ICitiesRepository _citiesRepository;

        public SearchCityUseCase()
        {
            _citiesRepository = new CitiesRepository();
        }

        public IEnumerable<CityDetails> Execute(string name)
        {
            return _citiesRepository.GetCityDetails(name);
        }
    }
}
