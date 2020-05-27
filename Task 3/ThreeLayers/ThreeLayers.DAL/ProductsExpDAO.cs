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
    public class ProductsExpDAO : IProductsExpDAO
    {
        private string _connectionString = @"";
        public IEnumerable<ProductExp> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllProductsExp"; //данная хранимая процедура еще не создана!!!! СОЗДАЙ!

                connection.Open();
                var reader = command.ExecuteReader();
                List<ProductExp> ProductExpList = new List<ProductExp>();
                while (reader.Read())
                {
                    //здесь можно будет заранее привести тип DATE из ридера а потом сразу отправить DateTime
                    ProductExpList.Add(new ProductExp(reader["Name"] as string, 
                        reader["expd"] as string,
                        (DateTime)reader["Date"]/*Вот тут загвоздка с приведениием типов надо либо изменить тип данных в базе данных на Data либо придумать как положить в конструктор дату из SQL*/));
                }//данный шаблон еще не работает из-за отсутствия хранимки и приведения типов 
                return ProductExpList;
            }

        }
    }
}
