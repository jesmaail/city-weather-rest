using CityWeather.Data.Interfaces;
using CityWeather.Entities;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace CityWeather.Data
{
    public class CountryInfoRepository : ICountryInfoRepository
    {
        private RestClient _restClient;

        private const string REST_COUNTRIES_ENDPOINT = "http://restcountries.eu";
        private const string REST_COUNTRIES_RESOURCE = "/rest/v2/name";

        private const string TWO_DIGIT_COUNTRY_CODE_KEY = "alpha2Code";
        private const string THREE_DIGIT_COUNTRY_CODE_KEY = "alpha3Code";
        private const string CURRENCY_LIST_KEY = "currencies";
        private const string CURRENCY_CODE_KEY = "code";

        public CountryInfoRepository()
        {
            _restClient = new RestClient(REST_COUNTRIES_ENDPOINT);
        }

        public CountryInfo GetCountryInformation(string name)
        {
            var response = _restClient.Execute(new RestRequest($"{REST_COUNTRIES_RESOURCE }/{name}"));

            var contentList = JArray.Parse(response.Content);            

            var content = JObject.Parse(contentList.First.ToString()); // Assuming one hit or only care about the first

            var result = new CountryInfo
            {
                TwoDigitCountryCode = content[TWO_DIGIT_COUNTRY_CODE_KEY].ToString(),
                ThreeDigitCountryCode = content[THREE_DIGIT_COUNTRY_CODE_KEY].ToString(),
                CurrencyCode = content[CURRENCY_LIST_KEY].First[CURRENCY_CODE_KEY].ToString() // Assume we only care about first hit for currency
            };
            return result;
        }
    }
}
