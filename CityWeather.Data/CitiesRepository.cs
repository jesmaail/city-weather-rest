using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CityWeather.Data.Interfaces;
using CityWeather.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace CityWeather.Data
{
    public class CitiesRepository : ICitiesRepository
    {
        private SqlConnection _connection;

        private const string GET_CITY_SPROC = "dbo.GetCity";
        private const string DELETE_CITY_SPROC = "dbo.DeleteCity";
        private const string STORE_CITY_SPROC = "dbo.StoreCity";
        private const string UPDATE_CITY_SPROC = "dbo.UpdateCity";

        public CitiesRepository(IConfiguration configuration)
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = configuration["DatabaseConnectionString"];
        }

        public void DeleteCityDetails(int id)
        {
            _connection.Execute(DELETE_CITY_SPROC,
                new
                {
                    id = id
                }, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<CityDetails> GetCityDetails(string name)
        {
            return _connection.Query<CityDetails>(GET_CITY_SPROC,
                new
                {
                    name = name
                }, commandType: CommandType.StoredProcedure);
        }

        public void StoreCityDetails(CityDetails city)
        {
            _connection.Execute(STORE_CITY_SPROC,
                new
                {
                    name = city.Name,
                    state = city.State,
                    countryName = city.CountryName,
                    rating = city.Rating,
                    established = city.Established,
                    estimatedPopulation = city.EstimatedPopulation
                }, commandType: CommandType.StoredProcedure);

        }

        public void UpdateCityDetails(int id, int rating, DateTime established, int estimatedPopulation)
        {
            _connection.Execute(UPDATE_CITY_SPROC,
                new
                {
                    id = id,
                    rating = rating,
                    established = established,
                    estimatedPopulation = estimatedPopulation
                }, commandType: CommandType.StoredProcedure);
        }
    }
}
