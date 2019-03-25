using CityWeather.Data;

namespace CityWeather.Application
{
    public class DeleteCityUseCase
    {
        private readonly ICitiesRepository _citiesRepository;

        public DeleteCityUseCase()
        {

        }

        public void Execute(int id)
        {
            _citiesRepository.DeleteCityDetails(id);
        }
    }
}
