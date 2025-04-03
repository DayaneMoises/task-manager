using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Models.InputModels;
using TaskManager.API.Services;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TasksController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var task = _taskService.GetTaskById(id);
            return task == null ? NotFound() : Ok(task);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TaskInputModel novaTask)
        {
            _taskService.CreateTask(novaTask);
            return Created("", novaTask);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] TaskInputModel taskAtualizada)
        {
            var updated = _taskService.UpdateTask(id, taskAtualizada);
            return updated ? Ok(taskAtualizada) : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var deleted = _taskService.DeleteTask(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
