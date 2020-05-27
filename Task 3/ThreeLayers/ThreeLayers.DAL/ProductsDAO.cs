using System;
using ThreeLayers.Dao.Interfaces;
using ThreeLayers.Entities;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ThreeLayers.DAL
{
    public class ProductsDAO : IProductsDAO
    {
        private string _connectionString = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=Recipe;Integrated Security=True";
        private static Dictionary<int, Products> _products = new Dictionary<int, Products>();
        public void Add(Products d)
        {
            int lastKey = _products.Keys.LastOrDefault();
            d.Id = lastKey + 1;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddProduct";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = d.Id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);

                var nameParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Name",
                    Value = d.Name,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(nameParameter);

                var weightParameter = new SqlParameter()
                {
                    DbType = DbType.Decimal,
                    ParameterName = "@Weight",
                    Value = d.Weight,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(weightParameter);

                var calloriesParameter = new SqlParameter()
                {
                    DbType = DbType.Decimal,
                    ParameterName = "@Callories",
                    Value = d.Callories,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(calloriesParameter);

                var isveganParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IsVegan",
                    Value = d.IsVegan,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(isveganParameter);

                var priceParameter = new SqlParameter()
                {
                    DbType = DbType.Decimal,
                    ParameterName = "@Price",
                    Value = d.Price,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(priceParameter);

                var EXPParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@EXP",
                    Value = d.EXP,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(EXPParameter);
                connection.Open();
                var reader = command.ExecuteReader();
            }
        }
        public void Remove(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemoveProductById";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);

                connection.Open();
                var reader = command.ExecuteReader();
            }
        }
        public Products GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetProductsById";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);

                connection.Open();
                var reader = command.ExecuteReader();
                Products ChosenDish = null;
                while (reader.Read())
                {
                    ChosenDish = new Products((int)reader["IdProduct"],
                        reader["Name"] as string,
                        (decimal)reader["Weight"],
                        (decimal)reader["Callories"],
                        (int)reader["IsVegan"],
                        (decimal)reader["Price"],
                        (int)reader["EXP"]
                        );
                }
                return ChosenDish;
            }
        }
        public IEnumerable<Products> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllProducts";

                connection.Open();
                var reader = command.ExecuteReader();
                List< Products> Products = new List<Products>();
                while (reader.Read())
                {//public Dish(int id, string n, decimal w, decimal c,int coun, int isv, double pr, int EXP,int i)
                    Products.Add(new Products((int)reader["IdProduct"],
                        reader["Name"] as string,
                        (decimal)reader["Weight"],
                        (decimal)reader["Callories"],
                        (int)reader["IsVegan"],
                        (decimal)reader["Price"],
                        (int)reader["EXP"]));
                }
                return Products;
            }
        }
        //Самая важная потому что вызывает процедуру GreatProducts которая отправляет все в More10 table
        public void GreateProducts()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GreatProducts";

                connection.Open();
                var reader = command.ExecuteReader();
            }
        }
    }
}