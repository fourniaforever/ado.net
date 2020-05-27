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
    public class GroupOfDishesDAO : IGroupOfDishesDAO
    {
        private string _connectionString = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=Recipe;Integrated Security=True";
        private static Dictionary<int, GroupOfDishes> _dishes = new Dictionary<int, GroupOfDishes>();
        public void Add(GroupOfDishes d)
        {
            int lastKey = _dishes.Keys.LastOrDefault();
            d.id = lastKey + 1;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddGroupOfDish";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdGroup",
                    Value = d.id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);

                var iddParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdDish",
                    Value = d.iddish,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(iddParameter);

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
                command.CommandText = "dbo.RemoveGroupOfDishesById";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdGroup",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);

                connection.Open();
                var reader = command.ExecuteReader();
            }
        }
        public GroupOfDishes GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetGroupOfDishesById";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@IdGroup",
                    Value = id,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParameter);

                connection.Open();
                var reader = command.ExecuteReader();
                GroupOfDishes Chosengroup = null;
                while (reader.Read())
                {
                    Chosengroup = new GroupOfDishes((int)reader["IdGroup"], (int)reader["IdDish"],
                        reader["Name"] as string);
                }
                return Chosengroup;
            }
        }
        public IEnumerable<GroupOfDishes> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllGroupOfDishes";

                connection.Open();
                var reader = command.ExecuteReader();
                List<GroupOfDishes> Groups = new List<GroupOfDishes>();
                while (reader.Read())
                {//public Dish(int id, string n, decimal w, decimal c,int coun, int isv, double pr, int EXP,int i)
                    Groups.Add(new GroupOfDishes((int)reader["IdGroup"], (int)reader["IdDish"],
                        reader["Name"] as string));
                }
                return Groups;
            }
        }
    }
}