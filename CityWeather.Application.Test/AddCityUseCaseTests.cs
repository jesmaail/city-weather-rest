using CityWeather.Data.Interfaces;
using CityWeather.Entities;
using Moq;
using NUnit.Framework;
using System;

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
                State = "State Bar",
                Rating = 2,
                Established = new DateTime(2001, 01, 01)
            };

            var sut = new AddCityUseCase(_citiesRepositoryMock.Object);
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

            var sut = new AddCityUseCase(_citiesRepositoryMock.Object);
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

            var sut = new AddCityUseCase(_citiesRepositoryMock.Object);
            Assert.Throws<ArgumentException>(() => sut.Execute(testData));
        }
    }
}
