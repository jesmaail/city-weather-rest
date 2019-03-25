using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CityWeather.Data.Interfaces;
using CityWeather.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace CityWeather.Data
{
    public class CitiesRepository : ICitiesRepository
    {
        // TODO 
        // - SProcs
        // - ORM
        // - At least cleanup the Queries!

        private SqlConnection _connection;

        public CitiesRepository(IConfiguration configuration)
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = configuration["DatabaseConnectionString"];
        }

        public void DeleteCityDetails(int id)
        {
            _connection.Execute($"DELETE FROM Cities WHERE Id = {id}");
        }

        public IEnumerable<CityDetails> GetCityDetails(string name)
        {
            return _connection.Query<CityDetails>($"SELECT * FROM Cities WHERE Name = '{name}'");
        }

        public void StoreCityDetails(CityDetails city)
        {
            _connection.Execute($"INSERT INTO Cities (Name, State, CountryName, Rating, Established, EstimatedPopulation) Values('{city.Name}', '{city.State}', '{city.CountryName}', {city.Rating}, '{city.Established}', {city.EstimatedPopulation});");
        }

        public void UpdateCityDetails(int id, int rating, DateTime established, int estimatedPopulation)
        {
            _connection.Execute($"UPDATE Cities SET Rating = '{rating}', Established = '{established}', EstimatedPopulation = '{estimatedPopulation}' WHERE Id = {id}");
        }
    }
}
