using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MINT_WebAPI.Constants;
using MINT_WebAPI.Models;
using System.Data;

namespace MINT_WebAPI.DataControllers
{
    public class CustomersDataController
    {
        private readonly string _connectionString;

        private SqlConnection GetConnection() => new(_connectionString);

        public CustomersDataController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            using var connection = GetConnection();
            connection.Open();
            var rows = connection.Query<Customer>(
                DatabaseConstants.GetAllCustomers,
                commandType: CommandType.StoredProcedure);
            return rows;
        }

        public Customer? GetCustomerById (int id)
        {
            using var connection = GetConnection();
            connection.Open();
            var row = connection.QueryFirstOrDefault<Customer>(
                DatabaseConstants.GetCustomerById,
                new
                {
                    CustomerId = id,
                },
                commandType: CommandType.StoredProcedure);
            return row;
        }

        public Customer? GetCustomerByName(string firstName)
        {
            using var connection = GetConnection();
            connection.Open();
            var row = connection.QueryFirstOrDefault<Customer>(
                DatabaseConstants.GetCustomerByName,
                new
                {
                    FirstName = firstName,
                },
                commandType: CommandType.StoredProcedure);
            return row;
        }

        public int CreateCustomer(Customer customer)
        {
            using var connection = GetConnection();
            connection.Open();
            var row = connection.Execute(
                DatabaseConstants.CreateCustomer,
                new
                {
                    customer.FirstName,
                    customer.LastName,
                    customer.Phone,
                    customer.Email,
                    customer.Street,
                    customer.City,
                    customer.State,
                    customer.ZipCode,
                },
                commandType: CommandType.StoredProcedure);
            return row;
        }

        public int UpdateCustomer(Customer customer)
        {
            using var connection = GetConnection();
            connection.Open();
            var row = connection.Execute(
                DatabaseConstants.UpdateCustomer,
                new
                {
                    customer.CustomerId,
                    customer.FirstName,
                    customer.LastName,
                    customer.Phone,
                    customer.Email,
                    customer.Street,
                    customer.City,
                    customer.State,
                    customer.ZipCode,
                },
                commandType: CommandType.StoredProcedure);
            return row;
        }

        public int DeleteCustomerById(int id)
        {
            using var connection = GetConnection();
            connection.Open();
            var row = connection.Execute(
                DatabaseConstants.DeleteCustomerById,
                new
                {
                    CustomerId = id,
                },
                commandType: CommandType.StoredProcedure);
            return row;
        }
    }
}
