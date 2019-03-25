using System;

namespace CityWeather.Application.Interfaces
{
    public interface IValidator
    {
        void ValidateTouristRating(int rating);
        void ValidateEstablishedDate(DateTime established);
    }
}
