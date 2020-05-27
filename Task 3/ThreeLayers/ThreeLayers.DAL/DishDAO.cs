using System;
using ThreeLayers.Entities;
using ThreeLayers.Dao.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ThreeLayers.DAL
{
    public class DishDAO: IDishDao
    {
        private string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Recipe;Integrated Security=True";
        private static Dictionary<int, Dish> _dishes = new Dictionary<int, Dish>();
        public void Add(Dish d)
        {
            int lastKey = _dishes.Keys.LastOrDefault();
            d.Id = lastKey + 1;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddDish";

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

                var countryParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Country",
                    Value = d.Country,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(countryParameter);

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

                var idlistParameter = new SqlParameter()
                {
                    DbType = DbType.Decimal,
                    ParameterName = "@IDList",
                    Value = d.idlist,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idlistParameter);

                connection.Open();
                var reader = command.ExecuteReader();
            }
        }
        public void RemoveById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemoveDishById";

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

        public Dish GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetDishById";

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
                Dish ChosenDish = null;
                while (reader.Read())
                {//public Dish(int id, string n, decimal w, decimal c,int coun, int isv, double pr, int EXP,int i)
                    ChosenDish = new Dish((int)reader["IdDish"],
                        reader["Name"] as string,
                        (decimal)reader["Weight"],
                        (decimal)reader["Callories"],
                        (int)reader["Country"],
                        (int)reader["IsVegan"],
                        (decimal)reader["Price"],
                        (int)reader["EXP"],
                        (int)reader["IDList"]);
                }
                return ChosenDish;
            }
        }
        public IEnumerable<Dish> GetAll()
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllDish", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                connection.Open();
                var reader = cmd.ExecuteReader();
                List <Dish> Dishes = new List<Dish>();
                while (reader.Read())
                {
                    Dishes.Add(new Dish((int)reader["IdDish"], 
                        reader["Name"] as string, 
                        (decimal)reader["Weight"],
                        (decimal)reader["Callories"],
                        (int)reader["Country"],
                        (int)reader["IsVegan"],
                        (decimal)reader["Price"],
                        (int)reader["EXP"], 
                        (int)reader["IDList"]));
                }
                return Dishes;
            }
            
        }

        public void VegetarianSortByid(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.IsVeganD";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@param",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);

                connection.Open();
                var reader = command.ExecuteNonQuery();
            }
        }

        public void PriceAnalysis()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.PriceAnalysis";

                connection.Open();
                var reader = command.ExecuteNonQuery();
            }
        }

        public void Repricing(int id, int coeficcient)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.Repricing";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@id",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);

                var coeficcientParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@x",
                    Value = coeficcient,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(coeficcientParameter);

                connection.Open();
                var reader = command.ExecuteNonQuery();
            }
        }

      public IEnumerable<string> SelectDishesFromCountry(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SelectDishesFromCountry", connection);  //SQL-команда
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCountry",id);
                connection.Open();
                var reader = cmd.ExecuteReader();
                List<string> Dishes = new List<string>();
                while (reader.Read())
                {
                    Dishes.Add(reader["Name"] as string);
                }
                return Dishes;
            }
        }
    }
}
