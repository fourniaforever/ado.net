using System;
using System.Collections.Generic;
using System.Text;
using ThreeLayers.Entities;
using ThreeLayers.Dao.Interfaces;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace ThreeLayers.DAL
{
    public class MoreTenDAO : IMoreTenDAO
    {
        private string _connectionString = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=Recipe;Integrated Security=True";
        public IEnumerable<MoreTen> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllMore10";

                connection.Open();
                var reader = command.ExecuteReader();
                List<MoreTen> MoreTenList = new List<MoreTen>();
                while (reader.Read())
                {
                    MoreTenList.Add(new MoreTen(reader["Name"] as string,
                        reader["days"] as string));
                }
                return MoreTenList;
            }
        }
    }
}
