using System;
using System.Collections.Generic;
using System.Text;

namespace CityWeather.Data.Interfaces
{
    interface IWeatherRepository
    {
        string GetWeather(string cityName);
    }
}
