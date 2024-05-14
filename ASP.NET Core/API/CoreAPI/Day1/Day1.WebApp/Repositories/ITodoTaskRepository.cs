using Day1.WebApp.Model;
namespace Day1.WebApp.Repositories

{
    public interface ITodoTaskRepository
    {
        TodoTask CreateTask(TodoTask task);
        TodoTask GetTaskById(Guid id);
        List<TodoTask> GetAll();
        TodoTask UpdateTask(Guid id, TodoTask task);
        TodoTask DeleteTask(Guid id);
        void BulkDelete(List<Guid> ids);
    }
}
