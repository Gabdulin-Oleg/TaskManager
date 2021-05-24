using AutoMapper;
using BL.Intefaces;
using BL.Intefaces.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TaskManager.Models;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace TaskManager.Controllers
{
    /// <summary>
    /// контроллер менеджера задач
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [SwaggerTag("Api For TaskManager")]
    public class TaskManagerController : ControllerBase
    {

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
        /// <summary>
        /// Создание задачи
        /// </summary>
        /// <param name="taskViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateTask(TaskViewModel taskViewModel)
        {
            if (Validator.TryValidateObject(taskViewModel, new ValidationContext(taskViewModel), new List<ValidationResult>()))
                return Ok(taskManageService.CreateTask(mapper.Map<TaskDto>(taskViewModel)));

            return BadRequest();
        }
        /// <summary>
        /// Обновление задачи
        /// </summary>
        /// <param name="taskViewModel"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpDateTask(TaskViewModel taskViewModel)
        {
            if (Validator.TryValidateObject(taskViewModel, new ValidationContext(taskViewModel), new List<ValidationResult>()))
                return Ok(taskManageService.UpDate(mapper.Map<TaskDto>(taskViewModel)));

            return BadRequest();
        }
        /// <summary>
        /// Получение задачи по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetTask/{id}")]
        public IActionResult GetTask(int id)
        {
            var respons = taskManageService.GetTaskById(id);
            if (respons != null)
                return Ok(respons);

            return NotFound();
        }
        /// <summary>
        /// Получение всех задач
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllTasks(string filter)
        {
            //taskManageService.CheckingDelinquency();
            return Ok(taskManageService.GetTasksByFiltred(filter));
        }
    }
}
