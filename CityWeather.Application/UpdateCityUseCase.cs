﻿using CityWeather.Data;
using CityWeather.Entities;

namespace CityWeather.Application
{
    public class UpdateCityUseCase
    {
        private readonly ICitiesRepository _citiesRepository;

        public UpdateCityUseCase()
        {
            _citiesRepository = new CitiesRepository();
        }

        public void Execute(int id, CityDetails cityDetails)
        {
            _citiesRepository.UpdateCityDetails(id, cityDetails);
        }
    }
}
