using MyTasksManager.Helpers.Enums;

namespace MyTasksManager.Models
{
    public class TaskModel
    {
        public string TaskId { get; private set; }
        public string TaskName { get; set; }
        public string Description { get; set; }

        public string DateTimeDue { get; set; }

        public TaskStatus Status { get; set; }

        public int CategoryId { get; set; }

        public TaskModel() {
            Status = TaskStatus.Pending;
        }

        public TaskModel(string taskName, string description, string datetTimeDue, int categoryId = 0) : base()
        {
            this.TaskName = taskName;
            this.Description = description;
            this.DateTimeDue = datetTimeDue;
            this.CategoryId = categoryId;
        }
    }
}
