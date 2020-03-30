using Dapper;
using MyTasksManager.Models;
using System.Collections.Generic;
using System.Data;

namespace DbRepository.Task
{
    public class GetTasks: Query
    {
        public GetTasks() { }

        public List<TaskModel> Execute()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<TaskModel>("SELECT * FROM tasks").AsList();
            }
        }
    }
}
