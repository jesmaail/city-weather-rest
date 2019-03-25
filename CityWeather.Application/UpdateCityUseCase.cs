using CityWeather.Application.Interfaces;
using CityWeather.Data.Interfaces;
using System;

namespace CityWeather.Application
{
    public class UpdateCityUseCase : IUpdateCityUseCase
    {
        private readonly ICitiesRepository _citiesRepository;

        public UpdateCityUseCase(ICitiesRepository citiesRepository)
        {
            _citiesRepository = citiesRepository;
        }

        public void Execute(int id, int rating, DateTime established, int estimatedPopulation)
        {
            Validator.ValidateTouristRating(rating);
            Validator.ValidateEstablishedDate(established);

            _citiesRepository.UpdateCityDetails(id, rating, established, estimatedPopulation);
        }
    }
}
