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
    public class CountriesDAO : ICountriesDao
    {
        private string _connectionString = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=Recipe;Integrated Security=True";
        private static Dictionary<int, Countries> _countries = new Dictionary<int, Countries>();
        public void Add(Countries d)
        {
            int lastKey = _countries.Keys.LastOrDefault();
            d.Id = lastKey + 1;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddCountry";

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
                command.CommandText = "dbo.RemoveCountryById";

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
        public Countries GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetCountryById";

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
                Countries ChosenCountry = null;
                while (reader.Read())
                {//public Dish(int id, string n, decimal w, decimal c,int coun, int isv, double pr, int EXP,int i)
                    ChosenCountry = new Countries((int)reader["IdCountry"],
                        reader["Name"] as string);
                }
                return ChosenCountry;
            }
        }
        public IEnumerable<Countries> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllDishes";

                connection.Open();
                var reader = command.ExecuteReader();
                List<Countries> Countries = new List<Countries>();
                while (reader.Read())
                {//public Dish(int id, string n, decimal w, decimal c,int coun, int isv, double pr, int EXP,int i)
                    Countries.Add(new Countries((int)reader["IdDish"],
                        reader["Name"] as string
                       ));
                }
                return Countries;
            }

        }
    }
}