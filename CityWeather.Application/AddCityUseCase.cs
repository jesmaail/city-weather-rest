using CityWeather.Application.Interfaces;
using CityWeather.Data.Interfaces;
using CityWeather.Entities;

namespace CityWeather.Application
{
    public class AddCityUseCase : IAddCityUseCase
    {
        private readonly ICitiesRepository _citiesRepository;
        private readonly IValidator _validator;

        public AddCityUseCase(ICitiesRepository citiesRepository, IValidator validator)
        {
            _citiesRepository = citiesRepository;
            _validator = validator;
        }

        public void Execute(CityDetails cityDetails)
        {
            _validator.ValidateTouristRating(cityDetails.Rating);
            _validator.ValidateEstablishedDate(cityDetails.Established);

            _citiesRepository.StoreCityDetails(cityDetails);
        }        
    }
}
