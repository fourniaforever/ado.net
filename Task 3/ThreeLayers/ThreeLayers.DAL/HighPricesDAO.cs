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
    public class HighPricesDAO : IHighPricesDAO
    {
        private string _connectionString = @"";
        public IEnumerable<HighPrices> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllHighPrice";

                connection.Open();
                var reader = command.ExecuteReader();
                List<HighPrices> HighPriceList = new List<HighPrices>();
                while (reader.Read())
                {
                    HighPriceList.Add(new HighPrices(reader["Name"] as string,
                        reader["Rich"] as string));
                }
                return HighPriceList;
            }
        }
    }
}
