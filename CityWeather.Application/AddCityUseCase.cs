using CityWeather.Application.Interfaces;
using CityWeather.Data.Interfaces;
using CityWeather.Entities;

namespace CityWeather.Application
{
    public class AddCityUseCase : IAddCityUseCase
    {
        private readonly ICitiesRepository _citiesRepository;

        public AddCityUseCase(ICitiesRepository citiesRepository)
        {
            _citiesRepository = citiesRepository;
        }

        public void Execute(CityDetails cityDetails)
        {
            _citiesRepository.StoreCityDetails(cityDetails);
        }
    }
}
