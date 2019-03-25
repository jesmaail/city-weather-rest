using CityWeather.Data.Interfaces;
using CityWeather.Entities;
using Moq;
using NUnit.Framework;

namespace CityWeather.Application.Test
{
    [TestFixture]
    public class AddCityUseCaseTests
    {
        private Mock<ICitiesRepository> _citiesRepositoryMock = new Mock<ICitiesRepository>();

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void add_city_calls_city_repository_with_correct_data()
        {
            var testData = new CityDetails
            {
                Name = "Foo",
                CountryName = "Country Foo",
                State = "State Bar"
            };

            var sut = new AddCityUseCase(_citiesRepositoryMock.Object);
            sut.Execute(testData);

            _citiesRepositoryMock.Verify(x => x.StoreCityDetails(testData), Times.Once);
        }
    }
}
