using CityWeather.Application.Interfaces;
using CityWeather.Data.Interfaces;
using Moq;
using NUnit.Framework;
using System;

namespace CityWeather.Application.Test
{
    [TestFixture]
    public class UpdateCityUseCaseTests
    {
        private Mock<ICitiesRepository> _citiesRepositoryMock = new Mock<ICitiesRepository>();
        private Mock<IValidator> _validator = new Mock<IValidator>();

        [SetUp]
        public void SetUp()
        {
        }

        [TestCase(1, 3, "01-01-2001", 12)]
        [TestCase(2, 5, "03-03-1803", 500)]
        public void update_city_calls_city_repository_with_correct_data(int id, int rating, string established, int estimatedPopulation)
        {
            var sut = new UpdateCityUseCase(_citiesRepositoryMock.Object, _validator.Object);
            
            var establihsedDateTime = Convert.ToDateTime(established);

            sut.Execute(id, rating, establihsedDateTime, estimatedPopulation);

            _citiesRepositoryMock.Verify(x => x.UpdateCityDetails(id, rating, establihsedDateTime, estimatedPopulation), Times.Once);
        }
    }
}
