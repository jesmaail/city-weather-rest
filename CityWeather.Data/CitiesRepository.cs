using System.Collections.Generic;
using System.Data.SqlClient;
using CityWeather.Data.Interfaces;
using CityWeather.Entities;
using Dapper;

namespace CityWeather.Data
{
    public class CitiesRepository : ICitiesRepository
    {
        // TODO 
        // - Don't keep DB info here
        // - SProcs
        // - ORM
        // - At least cleanup the Queries!

        private SqlConnection _connection;
        public CitiesRepository()
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = "Server=localhost,1433;Database=Cities;User Id=sa; Password=Letmein123!"; 
            // Thankfully this is a docker instance to spin up and down, this needs to live somewhere secure and definitely not in code ;) TODO TODO TODO
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

        public void UpdateCityDetails(int id, CityDetails city)
        {
            _connection.Execute($"UPDATE Cities SET Rating = '{city.Rating}', Established = '{city.Established}', EstimatedPopulation = '{city.EstimatedPopulation}' WHERE Id = {id}");
        }
    }
}
