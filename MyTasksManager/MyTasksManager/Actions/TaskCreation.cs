using DbRepository.Task;
using MyTasksManager.Models;

namespace MyTasksManager.Actions
{
    public class TaskCreation
    {
        readonly CreateTask _CreateTask;
        public TaskCreation(CreateTask createTask)
        {
            _CreateTask = createTask;
        }

        public TaskModel CreateTask(string taskName, string description, string dateTimeDue)
        {
            if (taskName == null)
                return null;

            var task = new TaskModel(taskName, description, dateTimeDue);

            bool result = _CreateTask.Execute(task);

            if (!result)
                return null;

            return task;
        }
    }
}
