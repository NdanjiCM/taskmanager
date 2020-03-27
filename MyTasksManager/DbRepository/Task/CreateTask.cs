using Dapper;
using MyTasksManager.Models;
using System.Data;

namespace DbRepository.Task
{
    public class CreateTask: Query
    {
        public CreateTask():base() { }

        public bool Execute(TaskModel task) {

            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                int result = dbConnection.Execute($"INSERT INTO tasks (taskname, description, duedate, status, categoryid) " +
                    $"VALUES(@TaskName, @Description, @DateTimeDue, @Status, @CategoryId)", task);

                return result == 1;
            }
        }
    }
}
