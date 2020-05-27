using System;
using System.Collections.Generic;
using System.Text;
using ThreeLayers.Dao.Interfaces;
using ThreeLayers.Entities;
using System.Data;
using System.Data.SqlClient;
namespace ThreeLayers.DAL
{
    public class NotVeganRecipsDAO : INotVeganRecipsDAO
    {
        private string _connectionString = "@";
        public IEnumerable<NotVeganRecips> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllNotVeganDishes";

                connection.Open();
                var reader = command.ExecuteReader();
                List<NotVeganRecips> NotVeganRecipses = new List<NotVeganRecips>();
                while (reader.Read())
                {
                    NotVeganRecipses.Add(new NotVeganRecips(reader["Name"] as string,
                        reader["Vegan"] as string));

                }
                return NotVeganRecipses;
            }
        }

        public NotVeganRecips GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
