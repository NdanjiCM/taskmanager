using Dapper;
using MyTasksManager.Models;
using System.Collections.Generic;
using System.Data;

namespace DbRepository.Categories
{
    public class GetCategories : Query
    {
        public GetCategories() { }

        public List<Category> Execute()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Category>("SELECT * FROM category").AsList();
            }
        }
    }
}
