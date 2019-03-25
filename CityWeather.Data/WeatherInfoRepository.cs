using CityWeather.Data.Interfaces;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace CityWeather.Data
{
    public class WeatherInfoRepository : IWeatherInfoRepository
    {
        private RestClient _restClient;

        private const string OPEN_WEATHER_ENDPOINT = "http://api.openweathermap.org";
        private const string OPEN_WEATHER_RESOURCE = "/data/2.5/weather";

        private const string API_KEY = "e851eca9b5c8361946869bee54f18c6e"; // Wants to NOT be in code!!

        public WeatherInfoRepository()
        {
            _restClient = new RestClient(OPEN_WEATHER_ENDPOINT);
        }

        public string GetWeather(string cityName, string countryCode)
        {
            //q={cityName},{countryCode}&APPID={API_KEY}

            var request = new RestRequest(OPEN_WEATHER_RESOURCE);
            request.AddQueryParameter("q", $"{cityName},{countryCode}"); 
            request.AddQueryParameter("APPID", API_KEY);

            var response = _restClient.Execute(request);

            var content = JObject.Parse(response.Content);

            return content["weather"].First["main"].ToString();
        }
    }
}
