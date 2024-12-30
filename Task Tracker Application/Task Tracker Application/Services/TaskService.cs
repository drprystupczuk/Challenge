using Task_Tracker_Application.Model;

namespace Task_Tracker_Application.Services
{
    public interface ITaskService
    {
        CustomTask AddTask(CustomTask task);

        List<CustomTask> Get();
    }
    public class TaskService : ITaskService
    {
        private static readonly List<CustomTask> tasks = new();

        public CustomTask AddTask(CustomTask task)
        {
            ValidateTaskProperties(task);

            tasks.Add(task);

            return task;
        }

        private static void ValidateTaskProperties(CustomTask task)
        {
            if (string.IsNullOrEmpty(task.Name))
                throw new Exception("Name is a mandatory field.");

            if (string.IsNullOrEmpty(task.Description))
                throw new Exception("Description is a mandatory field.");

            if (tasks.Exists(itemTask => itemTask.Name == task.Name))
                throw new Exception("Another task with the same name already exists.");
        }

        public List<CustomTask> Get() => tasks;
    }
}
