using CityWeather.Application.Interfaces;
using CityWeather.Data.Interfaces;
using CityWeather.Entities;

namespace CityWeather.Application
{
    public class UpdateCityUseCase : IUpdateCityUseCase
    {
        private readonly ICitiesRepository _citiesRepository;

        public UpdateCityUseCase(ICitiesRepository citiesRepository)
        {
            _citiesRepository = citiesRepository;
        }

        public void Execute(int id, CityDetails cityDetails)
        {
            _citiesRepository.UpdateCityDetails(id, cityDetails);
        }
    }
}
