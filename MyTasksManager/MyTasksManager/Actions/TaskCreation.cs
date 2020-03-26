using MyTasksManager.Models;

namespace MyTasksManager.Actions
{
    public class TaskCreation
    {
        public TaskModel CreateTask(string taskName, string description, string dateTimeDue)
        {
            if (taskName == null)
                return null;

            return new TaskModel(taskName, description, dateTimeDue);
        }
    }
}
