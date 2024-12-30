using Microsoft.AspNetCore.Mvc;
using Task_Tracker_Application.DTOs;
using Task_Tracker_Application.Model;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace Task_Tracker_Application.Controllers
{
    [ApiController]
    [Route("/api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly ILogger<TasksController> _logger;

        public TasksController(ILogger<TasksController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTasks")]
        public List<CustomTask> Get()
        {
            return new()
            {
                new CustomTask("Name", "Description"),
            };
        }

        [HttpPost()]
        public List<CustomTask> Post(JObject taskJson)
        {
            return new()
            {
                new CustomTask(
                    (string)taskJson.Property("Name"),
                    (string)taskJson.Property("Description"))
            };
        }
    }
}
