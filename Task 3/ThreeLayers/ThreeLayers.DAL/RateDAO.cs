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
    public class RateDAO : IRateDAO
    {
        private string _connectionString = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=Recipe;Integrated Security=True";
        
       private static Dictionary<int, Rate> _rates = new Dictionary<int, Rate>();
        public void Add(Rate p)
        {
            int lastKey = _rates.Keys.LastOrDefault();
            p.idDish = lastKey + 1;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddRate";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdDish",
                    Value = p.idDish,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);

                var DateParameter = new SqlParameter()
                {
                    DbType = DbType.DateTime,
                    ParameterName = "@Date",
                    Value = p.idDish,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(DateParameter);

                var rateParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Rate",
                    Value = p.Rating,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(rateParameter);

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
                command.CommandText = "dbo.RemoveRateById";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdDish",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);

                connection.Open();
                var reader = command.ExecuteReader();
            }
        }
        public Rate GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetRateById";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdDish",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);

                connection.Open();
                var reader = command.ExecuteReader();
                Rate ChosenRate = null;
                while (reader.Read())
                {
                    ChosenRate = new Rate((int)reader["IdDish"],(DateTime)reader["Date"],
                        (int)reader["Rate"]);
                }
                return ChosenRate;
            }
        }
        public IEnumerable<Rate> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllRate";

                connection.Open();
                var reader = command.ExecuteReader();
                List<Rate> Rates = new List<Rate>();
                while (reader.Read())
                {
                    Rates.Add(new Rate((int)reader["IdDish"], (DateTime)reader["Date"],
                        (int)reader["Rate"]));
                }
                return Rates;
            }
        }
    }
}