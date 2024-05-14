using Day1.WebApp.Model;
using Day1.WebApp.Services;

namespace Day1.WebApp.Repositories
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        public TodoTask CreateTask(TodoTask task)
        {
            Data.todoTasks.Add(task);
            return task;
        }

        public TodoTask GetTaskById(Guid id)
        {
            return Data.todoTasks.FirstOrDefault(t => t.Id == id);
        }

        public List<TodoTask> GetAll()
        {
            return Data.todoTasks;
        }

        public TodoTask UpdateTask(Guid id, TodoTask task)
        {
            var existingTask = Data.todoTasks.FirstOrDefault(t => t.Id == id);
            if (existingTask != null)
            {
                existingTask.Title = task.Title;
                existingTask.IsDone = task.IsDone;
            }
            return existingTask;
        }

        public TodoTask DeleteTask(Guid id)
        {
            var task = Data.todoTasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                Data.todoTasks.Remove(task);
            }
            return null;
        }

        public void BulkDelete(List<Guid> ids)
            {
                Data.todoTasks.RemoveAll(task => ids.Contains(task.Id));
            }       
    }
}
