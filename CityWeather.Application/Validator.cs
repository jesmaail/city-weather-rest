using CityWeather.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System;

namespace CityWeather.Application
{
    public class Validator : IValidator
    {
        private int _minTouristRating, _maxTouristRating;

        public Validator(IConfiguration configuration)
        {
            int.TryParse(configuration["MinTouristRating"], out _minTouristRating);
            int.TryParse(configuration["MaxTouristRating"], out _maxTouristRating);
        }

        public void ValidateTouristRating(int rating)
        {
            if (rating < _minTouristRating || rating > _maxTouristRating)
            {
                throw new ArgumentException("Bad Tourist Rating");
            }
        }

        public void ValidateEstablishedDate(DateTime established)
        {            
            if (established == new DateTime())
            {
                throw new ArgumentException("Bad Established Date");
            }
        }
    }
}
