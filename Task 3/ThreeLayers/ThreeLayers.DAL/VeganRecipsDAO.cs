using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ThreeLayers.Dao.Interfaces;
using ThreeLayers.Entities; 
namespace ThreeLayers.DAL
{
    public class VeganRecipsDAO : IVeganRecipsDao
    {
        private string _connectionString = @"";
        public IEnumerable<VeganRecips> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllVeganDishes";

                connection.Open();
                var reader = command.ExecuteReader();
                List<VeganRecips> VeganRecipses = new List<VeganRecips>();
                while (reader.Read())
                {
                    VeganRecipses.Add(new VeganRecips(reader["Name"] as string, 
                        reader["Vegan"] as string));

                }
                return VeganRecipses;
            }
            
        }

        public VeganRecips GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
