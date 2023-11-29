using Dapper;
using Microsoft.Data.SqlClient;
using MINT_WebAPI.Constants;
using MINT_WebAPI.Models;
using System.Data;

namespace MINT_WebAPI.DataControllers
{
    public class ProductsDataController
    {
        private readonly string _connectionString;

        private SqlConnection GetConnection() => new(_connectionString);

        public ProductsDataController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            using var connection = GetConnection();
            connection.Open();
            var rows = connection.Query<Product>(
                DatabaseConstants.GetAllProducts,
                commandType: CommandType.StoredProcedure);
            return rows;
        }

        public Product? GetProductById(int id)
        {
            using var connection = GetConnection();
            connection.Open();
            var row = connection.QueryFirstOrDefault<Product>(
                DatabaseConstants.GetProductById,
                new
                {
                    ProductId = id,
                },
                commandType: CommandType.StoredProcedure);
            return row;
        }

        public Product? GetProductByName(string productName)
        {
            using var connection = GetConnection();
            connection.Open();
            var row = connection.QueryFirstOrDefault<Product>(
                DatabaseConstants.GetProductByName,
                new
                {
                    ProductName = productName,
                },
                commandType: CommandType.StoredProcedure);
            return row;
        }

        public int CreateProduct(Product product)
        {
            using var connection = GetConnection();
            connection.Open();
            var row = connection.Execute(
                DatabaseConstants.CreateProduct,
                new
                {
                    product.ProductName,
                    product.BrandId,
                    product.CategoryId,
                    product.ModelYear,
                    product.Price,
                },
                commandType: CommandType.StoredProcedure);
            return row;
        }

        public int UpdateProduct(Product product)
        {
            using var connection = GetConnection();
            connection.Open();
            var row = connection.Execute(
                DatabaseConstants.UpdateProduct,
                new
                {
                    product.ProductId,
                    product.ProductName,
                    product.BrandId,
                    product.CategoryId,
                    product.ModelYear,
                    product.Price,
                },
                commandType: CommandType.StoredProcedure);
            return row;
        }

        public int DeleteProductById(int id)
        {
            using var connection = GetConnection();
            connection.Open();
            var row = connection.Execute(
                DatabaseConstants.DeleteProductById,
                new
                {
                    ProductId = id,
                },
                commandType: CommandType.StoredProcedure);
            return row;
        }
    }
}
