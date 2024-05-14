namespace Day1.WebApp.Model
{
    public class Data
    {
        public static List<TodoTask> todoTasks = new List<TodoTask>
        {
            new TodoTask{Id = Guid.NewGuid(), Title = "Task 1", IsDone = false },
            new TodoTask{Id = Guid.NewGuid(), Title = "Task 2", IsDone = true },
            new TodoTask{Id = Guid.NewGuid(), Title = "Task 3", IsDone = false },
            new TodoTask{Id = Guid.NewGuid(), Title = "Task 4", IsDone = false },
            new TodoTask{Id = Guid.NewGuid(), Title = "Task 5", IsDone = true },
            new TodoTask{Id = Guid.NewGuid(), Title = "Task 6", IsDone = false },
            new TodoTask{Id = Guid.NewGuid(), Title = "Task 7", IsDone = false },
            new TodoTask{Id = Guid.NewGuid(), Title = "Task 8", IsDone = true },
            new TodoTask{Id = Guid.NewGuid(), Title = "Task 9", IsDone = false },
            new TodoTask{Id = Guid.NewGuid(), Title = "Task 10", IsDone = false }
        };
    }
}
