using Dapper;
using MyTasksManager.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DbRepository.Categories
{
    public class GetCategories : Query
    {
        public GetCategories() { }

        public List<Category> Execute()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<Category>("SELECT * FROM category").AsList();
            }
        }
    }
}
