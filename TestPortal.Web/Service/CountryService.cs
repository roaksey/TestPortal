using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using TestPortal.Web.Models;
using TestPortal.Web.Service.Interface;

namespace TestPortal.Web.Service
{
    public class CountryService:ICountryService
    {
        private readonly string _connectionString;

        public CountryService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = "SELECT CountryId, CountryName FROM dbo.Country";
            var countries = await connection.QueryAsync<Country>(query);

            return countries;
        }

        public async Task<IEnumerable<City>> GetAllCitiesAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = "SELECT ID, Name,CountryId FROM dbo.Cities";
            var cities = await connection.QueryAsync<City>(query);

            return cities;
        }
    }
}
