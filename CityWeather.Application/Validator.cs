using System;

namespace CityWeather.Application
{
    public static class Validator
    {
        // Move to config
        private const int MIN_TOURIST_RATING = 1;
        private const int MAX_TOURIST_RATING = 5;

        public static void ValidateTouristRating(int rating)
        {
            if (rating < MIN_TOURIST_RATING || rating > MAX_TOURIST_RATING)
            {
                throw new ArgumentException("Bad Tourist Rating");
            }
        }

        public static void ValidateEstablishedDate(DateTime established)
        {            
            if (established == new DateTime())
            {
                throw new ArgumentException("Bad Established Date");
            }
        }
    }
}
