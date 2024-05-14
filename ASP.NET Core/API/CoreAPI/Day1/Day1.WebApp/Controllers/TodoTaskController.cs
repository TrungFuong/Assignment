using Day1.WebApp.Model;
using Day1.WebApp.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Day1.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoTaskController : ControllerBase
    {
        private readonly ITodoTaskService _service;
        public TodoTaskController(ITodoTaskService service)
        {
            _service = service;
        }
        // GET: api/<TodoController>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public IActionResult GetTaskById(Guid id)
        {
            TodoTask currentTask = _service.GetTaskById(id);
            if (currentTask == null)
            {
                return NotFound();
            }
            return Ok(currentTask);
        }

        // POST api/<TodoController>
        [HttpPost]
        public IActionResult CreateTask([FromBody] TodoTaskDTO taskDTO)
        {
            TodoTask task = new TodoTask
            {
                Id = Guid.NewGuid(),
                Title = taskDTO.Title,
                IsDone = taskDTO.IsDone
            };
            TodoTask createdTask = _service.CreateTask(task);
            if (createdTask == null)
            {
                return BadRequest();
            }
            return Ok(createdTask);
        }

        // PUT api/<TodoController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateTask(Guid id, [FromBody] TodoTaskDTO todoTaskDTO)
        {
            TodoTask todoTask = new TodoTask
            {
                Id = id,
                Title = todoTaskDTO.Title,
                IsDone = todoTaskDTO.IsDone
            };
            TodoTask updatedTask = _service.UpdateTask(id, todoTask);
            if (updatedTask == null)
            {
                return NotFound();
            }
            return Ok(updatedTask);
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            TodoTask currentTask = _service.GetTaskById(id);
            if (currentTask == null)
            {
                return NotFound();
            }
            _service.DeleteTask(id);
            return NoContent();
        }

        // POST api/<TodoController>/bulk
        [HttpPost("bulk")]
        public IActionResult BulkCreateTask([FromBody] List<TodoTaskDTO> tasksDTO)
        {
            List<TodoTask> tasks = new List<TodoTask>();
            foreach (var taskDTO in tasksDTO)
            {
                TodoTask task = new TodoTask
                {
                    Id = Guid.NewGuid(),
                    Title = taskDTO.Title,
                    IsDone = taskDTO.IsDone
                };
                tasks.Add(task);
            }
            List<TodoTask> createdTasks = _service.BulkCreateTask(tasks);
            return Ok(createdTasks);
        }

        // DELETE api/<TodoController>/bulk
        [HttpDelete("bulk")]
        public IActionResult BulkDelete([FromBody] List<Guid> ids)
        {
            _service.BulkDelete(ids);
            return NoContent();
        }

    }
}
