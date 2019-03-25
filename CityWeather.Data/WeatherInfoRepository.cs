using CityWeather.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace CityWeather.Data
{
    public class WeatherInfoRepository : IWeatherInfoRepository
    {
        private RestClient _restClient;
        private readonly IConfiguration _configuration;

        private const string OPEN_WEATHER_ENDPOINT = "http://api.openweathermap.org";
        private const string OPEN_WEATHER_RESOURCE = "/data/2.5/weather";

        public WeatherInfoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _restClient = new RestClient(OPEN_WEATHER_ENDPOINT);
        }

        public string GetWeather(string cityName, string countryCode)
        {
            //q={cityName},{countryCode}&APPID={API_KEY}

            var request = new RestRequest(OPEN_WEATHER_RESOURCE);
            request.AddQueryParameter("q", $"{cityName},{countryCode}"); 
            request.AddQueryParameter("APPID", _configuration["OpenWeatherApiKey"]);

            var response = _restClient.Execute(request);

            var content = JObject.Parse(response.Content);

            return content["weather"].First["main"].ToString();
        }
    }
}
