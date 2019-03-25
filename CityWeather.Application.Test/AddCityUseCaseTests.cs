using CityWeather.Application.Interfaces;
using CityWeather.Data.Interfaces;
using CityWeather.Entities;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;

namespace CityWeather.Application.Test
{
    [TestFixture]
    public class AddCityUseCaseTests
    {
        private Mock<ICitiesRepository> _citiesRepositoryMock = new Mock<ICitiesRepository>();
        private Mock<IValidator> _validatorMock = new Mock<IValidator>();
        private Mock<IConfiguration> _configurationMock = new Mock<IConfiguration>();

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
                State = "State Bar",
                Rating = 2,
                Established = new DateTime(2001, 01, 01)
            };

            var sut = new AddCityUseCase(_citiesRepositoryMock.Object, _validatorMock.Object);
            sut.Execute(testData);

            _citiesRepositoryMock.Verify(x => x.StoreCityDetails(testData), Times.Once);
        }

        [TestCase(0)]
        [TestCase(6)]
        public void add_city_throws_argument_exception_with_bad_tourist_rating(int rating)
        {
            var testData = new CityDetails
            {
                Name = "Foo",
                CountryName = "Country Foo",
                State = "State Bar",
                Rating = rating,
                Established = new DateTime(2001, 01, 01)
            };

            _configurationMock.Setup(x => x["MinTouristRating"]).Returns("1");
            _configurationMock.Setup(x => x["MaxTouristRating"]).Returns("5");

            var validator = new Validator(_configurationMock.Object);

            var sut = new AddCityUseCase(_citiesRepositoryMock.Object, validator);
            Assert.Throws<ArgumentException>(() => sut.Execute(testData));
        }

        [Test]
        public void add_city_throws_argument_exception_with_bad_established_date()
        {
            var testData = new CityDetails
            {
                Name = "Foo",
                CountryName = "Country Foo",
                State = "State Bar",
                Rating = 4
            };

            _configurationMock.Setup(x => x["MinTouristRating"]).Returns("1");
            _configurationMock.Setup(x => x["MaxTouristRating"]).Returns("5");

            var validator = new Validator(_configurationMock.Object);

            var sut = new AddCityUseCase(_citiesRepositoryMock.Object, validator);
            Assert.Throws<ArgumentException>(() => sut.Execute(testData));
        }
    }
}
