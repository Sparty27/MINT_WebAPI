using Dapper;
using Microsoft.Data.SqlClient;
using MINT_WebAPI.Models;
using MINT_WebAPI.Constants;

namespace MINT_WebAPI.DataControllers
{
    public class BrandsDataController
    {
        private readonly string _connectionString;

        private SqlConnection GetConnection() => new(_connectionString);

        public BrandsDataController (IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            using var connection = GetConnection();
            connection.Open();

            var rows = connection.Query<Brand>(
                DatabaseConstants.GetAllBrands,
                commandType: System.Data.CommandType.StoredProcedure);
            return rows;
        }
    }
}
