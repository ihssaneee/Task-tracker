using Microsoft.AspNetCore.Mvc;
using TaskTrackerApi.Models;
using TaskTrackerApi.Services;
using TaskTrackerApi.Dtos;

namespace TaskTrackerApi.Controllers
{
    [ApiController]
    [Route("api/tasks")]

    public class TaskController:ControllerBase
    {
       private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
public async Task<IActionResult> GetAll()
        {
            var tasks= await _taskService.GetAllAsync();
            return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
        {
            var taskFound = await _taskService.GetTaskItemAsync(id);
           if (taskFound==null)
           {
            return NotFound();
           }
            return Ok(taskFound);

        }

        [HttpPost]

    // public async Task<IActionResult> CreateTask(CreateTaskRequest request)
    //     {
           

    //         var taskCreated = await _taskService.CreateTaskAsync(request);
    //         return CreatedAtAction(nameof(GetById), new { id = taskCreated.Id }, taskCreated);
           
    //     }


        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateTask(UpdateTaskRequest request, int id)
        {
            var updatedTask= await _taskService.UpdateTaskAsync(id, request);
            if (updatedTask == null)
            {
                return NotFound();
            }
            return Ok(updatedTask);

            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var deletedTask= await _taskService.DeleteTaskAsync(id);
            if (!deletedTask)
            {
                return NotFound();
            }
            return NoContent();
        }
}
}