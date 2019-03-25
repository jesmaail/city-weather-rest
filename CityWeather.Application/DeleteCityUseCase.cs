using CityWeather.Application.Interfaces;
using CityWeather.Data.Interfaces;

namespace CityWeather.Application
{
    public class DeleteCityUseCase : IDeleteCityUseCase
    {
        private readonly ICitiesRepository _citiesRepository;

        public DeleteCityUseCase(ICitiesRepository citiesRepository)
        {
            _citiesRepository = citiesRepository;
        }

        public void Execute(int id)
        {
            _citiesRepository.DeleteCityDetails(id);
        }
    }
}
