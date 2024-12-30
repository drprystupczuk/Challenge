using Microsoft.AspNetCore.Mvc;
using Task_Tracker_Application.DTOs;
using Task_Tracker_Application.Model;
using Task_Tracker_Application.Services;

namespace Task_Tracker_Application.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ILogger<TasksController> _logger;
        
        private readonly ITaskService _taskService;

        public TasksController(ILogger<TasksController> logger, ITaskService taskService)
        {
            _logger = logger;
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_taskService.Get());
        

        [HttpPost]
        public IActionResult Post([FromBody]RequestTaskDTO taskDTO)
        {
            try
            {
                var task = _taskService.AddTask(new CustomTask(taskDTO.Name, taskDTO.Description));

                return CreatedAtAction(
                    nameof(Get),
                    new { id = task.Id },
                    task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
