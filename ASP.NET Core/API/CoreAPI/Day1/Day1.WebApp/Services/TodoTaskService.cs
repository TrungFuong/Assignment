using Day1.WebApp.Model;
using Day1.WebApp.Repositories;

namespace Day1.WebApp.Services
{
    public class TodoTaskService : ITodoTaskService
    {
        private readonly ITodoTaskRepository _repository;

        public TodoTaskService(ITodoTaskRepository repository)
        {
            _repository = repository;
        }

        public TodoTask CreateTask(TodoTask task)
        {

            return _repository.CreateTask(task);
        }

        public TodoTask GetTaskById(Guid id)
        {
            return _repository.GetTaskById(id);
        }

        public List<TodoTask> GetAll()
        {
            return _repository.GetAll();
        }

        public TodoTask UpdateTask(Guid id, TodoTask task)
        {
            TodoTask currentTask = _repository.GetTaskById(id);
            if (currentTask == null)
            {
                return null;
            }
            return _repository.UpdateTask(id, task);
        }

        public List<TodoTask> BulkCreateTask(List<TodoTask> tasks)
        {
            List<TodoTask> createdTasks = new List<TodoTask>();

            foreach (var task in tasks)
            {
                TodoTask createdTask = _repository.CreateTask(task);
                createdTasks.Add(createdTask);
            }

            return createdTasks;
        }

        public TodoTask DeleteTask(Guid id)
        {
            TodoTask task = _repository.GetTaskById(id);
            if (task == null)
            {
                return null;
            }
            return _repository.DeleteTask(id);
        }
        
        public void BulkDelete(List<Guid> ids)
        {
            _repository.BulkDelete(ids);
        }
    }
}
