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
    public class ProcessDAO : IProcessDAO
    {
        private string _connectionString = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=Recipe;Integrated Security=True";
        private static Dictionary<int, Process> _processes = new Dictionary<int, Process>();
        public void Add(Process p)
        {
            int lastKey = _processes.Keys.LastOrDefault();
            p.id = lastKey + 1;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddProcess";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = p.id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);

                var nameParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Name",
                    Value =p.Name,
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
                command.CommandText = "dbo.RemoveProcessById";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdProcess",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);

                connection.Open();
                var reader = command.ExecuteReader();
            }
        }
        public Process GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetProcessById";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdProcess",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);

                connection.Open();
                var reader = command.ExecuteReader();
                Process ChosenProcess = null;
                while (reader.Read())
                {
                    ChosenProcess = new Process((int)reader["IdProcess"],
                        reader["Name"] as string);
                }
                return ChosenProcess;
            }
        }
        public IEnumerable<Process> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllDishes";

                connection.Open();
                var reader = command.ExecuteReader();
                List<Process> Processes = new List<Process>();
                while (reader.Read())
                { 
                    Processes.Add(new Process((int)reader["IdProcess"],
                        reader["Name"] as string));
                }
                return Processes;
            }
        }
    }
}