using CityWeather.Data.Interfaces;
using Moq;
using NUnit.Framework;

namespace CityWeather.Application.Test
{
    [TestFixture]
    public class SearchCityUseCaseTests
    {
        private Mock<ICitiesRepository> _citiesRepositoryMock = new Mock<ICitiesRepository>();
        private Mock<ICountryInfoRepository> _countryInfoRepositoryMock = new Mock<ICountryInfoRepository>();
        private Mock<IWeatherInfoRepository> _weatherInfoRepositoryMock = new Mock<IWeatherInfoRepository>();

        [SetUp]
        public void SetUp()
        {
        }

        [TestCase("Swansea")]
        [TestCase("Cardiff")]
        public void search_city_calls_city_repository_with_correct_data(string cityName)
        {
            var sut = new SearchCityUseCase(_citiesRepositoryMock.Object, _countryInfoRepositoryMock.Object, _weatherInfoRepositoryMock.Object);

            sut.Execute(cityName);

            _citiesRepositoryMock.Verify(x => x.GetCityDetails(cityName), Times.Once);
        }
    }
}
