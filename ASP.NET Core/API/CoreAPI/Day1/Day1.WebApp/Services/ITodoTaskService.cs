using Day1.WebApp.Model;

namespace Day1.WebApp.Services
{
    public interface ITodoTaskService
    {
        TodoTask CreateTask(TodoTask task);
        TodoTask GetTaskById(Guid id);
        List<TodoTask> GetAll();
        TodoTask UpdateTask(Guid id, TodoTask task);
        List<TodoTask> BulkCreateTask(List<TodoTask> tasks);
        TodoTask DeleteTask(Guid id);
        void BulkDelete(List<Guid> ids);
    }
}
