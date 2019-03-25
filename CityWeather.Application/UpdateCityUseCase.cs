using CityWeather.Application.Interfaces;
using CityWeather.Data.Interfaces;
using System;

namespace CityWeather.Application
{
    public class UpdateCityUseCase : IUpdateCityUseCase
    {
        private readonly ICitiesRepository _citiesRepository;
        private readonly IValidator _validator;

        public UpdateCityUseCase(ICitiesRepository citiesRepository, IValidator validator)
        {
            _citiesRepository = citiesRepository;
            _validator = validator;
        }

        public void Execute(int id, int rating, DateTime established, int estimatedPopulation)
        {
            _validator.ValidateTouristRating(rating);
            _validator.ValidateEstablishedDate(established);

            _citiesRepository.UpdateCityDetails(id, rating, established, estimatedPopulation);
        }
    }
}
