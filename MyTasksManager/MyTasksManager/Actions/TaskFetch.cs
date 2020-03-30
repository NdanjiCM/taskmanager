using DbRepository.Task;
using MyTasksManager.Models;
using System.Collections.Generic;

namespace MyTasksManager.Actions
{
    public class TaskFetch
    {
        readonly GetTasks GetTasks;

        public TaskFetch(GetTasks getAllTasks)
        {
            GetTasks = getAllTasks;
        }

        public List<TaskModel> GetAllTasks()
        {
            return GetTasks.Execute();
        }
    }
}
