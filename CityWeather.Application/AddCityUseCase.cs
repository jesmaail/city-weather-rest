using CityWeather.Data;
using CityWeather.Entities;

namespace CityWeather.Application
{
    public class AddCityUseCase
    {
        private readonly ICitiesRepository _citiesRepository;

        public AddCityUseCase()
        {
            _citiesRepository = new CitiesRepository();
        }

        public void Execute(CityDetails cityDetails)
        {
            _citiesRepository.StoreCityDetails(cityDetails);
        }
    }
}
