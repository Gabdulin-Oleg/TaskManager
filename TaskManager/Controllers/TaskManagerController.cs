using AutoMapper;
using BL.Intefaces;
using BL.Intefaces.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace TaskManager.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [SwaggerTag("Api For TaskManager")]
    public class TaskManagerController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<TaskManagerController> _logger;
        private IMapper mapper;
        private ITaskManageService taskManageService;

        public TaskManagerController(ILogger<TaskManagerController> logger, IMapper mapper, ITaskManageService taskManageService)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TaskDto, TaskViewModel>();
                cfg.CreateMap<TaskViewModel, TaskDto>();
            });
            _logger = logger;
            this.mapper = new Mapper(config);
            this.taskManageService = taskManageService;
        }       
        [HttpPost]
        public IActionResult CreateTask(TaskViewModel taskViewModel)
        {
            if (Validator.TryValidateObject(taskViewModel, new ValidationContext(taskViewModel), new List<ValidationResult>()))
                return Ok(taskManageService.CreateTask(mapper.Map<TaskDto>(taskViewModel)));

            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpDateTask(TaskViewModel taskViewModel)
        {
            if (Validator.TryValidateObject(taskViewModel, new ValidationContext(taskViewModel), new List<ValidationResult>()))
                return Ok(taskManageService.UpDate(mapper.Map<TaskDto>(taskViewModel)));

            return BadRequest();
        }
        [HttpGet("{id}")]
        public IActionResult GetTask(int id)
        {
            return Ok(taskManageService.GetTaskById(id));
        }
        [HttpGet]
        public IActionResult GetAllTasks(string filter)
        {
            taskManageService.ChecStatus();
            return Ok(taskManageService.GetTasksByFiltred(filter));
        }
    }
}
