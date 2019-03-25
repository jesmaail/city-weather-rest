using CityWeather.Data.Interfaces;
using Moq;
using NUnit.Framework;

namespace CityWeather.Application.Test
{
    [TestFixture]
    public class DeleteCityUseCaseTests
    {
        private Mock<ICitiesRepository> _citiesRepositoryMock = new Mock<ICitiesRepository>();

        [SetUp]
        public void SetUp()
        {
        }

        [TestCase(1)]
        [TestCase(3)]
        public void delete_city_calls_city_repository_with_correct_data(int id)
        {
            var sut = new DeleteCityUseCase(_citiesRepositoryMock.Object);
            sut.Execute(id);

            _citiesRepositoryMock.Verify(x => x.DeleteCityDetails(id), Times.Once);
        }
    }
}
