using Dapper;
using MyTasksManager.Models;
using System.Data.SqlClient;

namespace DbRepository.Task
{
    public class CreateTask: Query
    {
        public CreateTask():base() { }

        public bool Execute(TaskModel task) {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                int result = connection.Execute($"INSERT INTO tasks (taskname, description, duedate, status, categoryid) " +
                    $"VALUES(@TaskName, @Description, @DateTimeDue, @Status, @CategoryId)", task);

                return result == 1;
            }
        }
    }
}
