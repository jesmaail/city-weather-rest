using CityWeather.Application.Interfaces;
using CityWeather.Data.Interfaces;
using CityWeather.Entities;
using System.Collections.Generic;

namespace CityWeather.Application
{
    public class SearchCityUseCase : ISearchCityUseCase
    {
        private readonly ICitiesRepository _citiesRepository;
        private readonly ICountryInfoRepository _countryInfoRepository;

        public SearchCityUseCase(ICitiesRepository citiesRepository, ICountryInfoRepository countryInfoRepository)
        {
            _citiesRepository = citiesRepository;
            _countryInfoRepository = countryInfoRepository;
        }

        public IEnumerable<CityDetails> Execute(string name)
        {
            var cityDetails = _citiesRepository.GetCityDetails(name);            

            // Want to check each time as the Country may differ (same-named cities)
            // e.g. Glasgow, Scotland and Glasgow, Montana
            foreach (var city in cityDetails)
            {
                var countryInfo = _countryInfoRepository.GetCountryInformation(city.CountryName);
                var weatherDetails = "";

                city.CountryInfo = countryInfo;
                city.CurrentWeather = weatherDetails;
            }           

            return cityDetails;
        }
    }
}
