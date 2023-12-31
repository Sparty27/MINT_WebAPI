﻿using Dapper;
using Microsoft.Data.SqlClient;
using MINT_WebAPI.Models;
using MINT_WebAPI.Constants;
using System.Data;

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
                commandType: CommandType.StoredProcedure);
            return rows;
        }

        public Brand? GetBrandById(int id)
        {
            using var connection = GetConnection();
            connection.Open();

            var row = connection.QueryFirstOrDefault<Brand>(
                DatabaseConstants.GetBrandById,
                new
                {
                    Id = id,
                },
                commandType: CommandType.StoredProcedure);
            return row;
        }

        public Brand? GetBrandByName(string name)
        {
            using var connection = GetConnection();
            connection.Open();

            var row = connection.QueryFirstOrDefault<Brand>(
                DatabaseConstants.GetBrandByName,
                new
                {
                    BrandName = name,
                },
                commandType: CommandType.StoredProcedure);
            return row;
        }

        public int CreateBrand(Brand brand)
        {
            using var connection = GetConnection();
            connection.Open();

            var row = connection.Execute(
                DatabaseConstants.CreateBrand,
                new
                {
                    brand.BrandName,
                },
                commandType: CommandType.StoredProcedure);
            return row;
        }

        public int UpdateBrand(Brand brand)
        {
            using var connection = GetConnection();
            connection.Open();

            var row = connection.Execute(
                DatabaseConstants.UpdateBrand,
                new
                {
                    brand.BrandId,
                    brand.BrandName,
                },
                commandType: CommandType.StoredProcedure);
            return row;
        }

        public int DeleteBrandById(int id)
        {
            using var connection = GetConnection();
            connection.Open();

            var row = connection.Execute(
                DatabaseConstants.DeleteBrandById,
                new
                {
                    BrandId = id,
                },
                commandType: CommandType.StoredProcedure);
            return row;
        }
    }
}
