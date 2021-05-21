using AutoMapper;
using BL.Intefaces;
using BL.Intefaces.DTO;
using DAL.Entitis;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Service
{
    class TaskManageService : ITaskManageService
    {
        ITaskRepository taskRepository;
        IMapper mapper;

        public TaskManageService(ITaskRepository taskRepository)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TaskDto, Task>();
                cfg.CreateMap<Task, TaskDto>();
            });
            this.taskRepository = taskRepository;
            this.mapper = new Mapper(config);
        }
        
        public TaskDto CreateTask(TaskDto taskDto)
        {
            taskDto.Status = TaskStatus.Active;
            taskDto.TaskCreateDate = DateTime.Now;
            taskRepository.Create(mapper.Map<Task>(taskDto));
            return taskDto;
        }

        public TaskDto UpDate(TaskDto taskDto)
        {
            taskRepository.UpData(mapper.Map<Task>(taskDto));
            return taskDto;
        }

        public ICollection<TaskDto> GetTasksByFiltred(string filter)
        {
            if (filter == null)
            {
                return mapper.Map<ICollection<TaskDto>>(taskRepository.GetAllTask().OrderByDescending(s=>s.Id));
            }
            var status = Enum.Parse<TaskStatus>(filter);
            return mapper.Map<ICollection<TaskDto>>(taskRepository.GetAllTask().Where(p => p.Status == status).OrderByDescending(s=>s.Id));
        }

        public TaskDto GetTaskById(int id)
        {
            return mapper.Map<TaskDto>(taskRepository.FindById(id));
        }

        public void ChecStatus()
        {
            var tasks = taskRepository
                .GetAllTask()
                .Where(p => p.TaskComplatedDate < DateTime.Now && p.Status != TaskStatus.Completed && p.Status != TaskStatus.Expired)
                .Select(p=>p);


            foreach (var task in tasks)
            {
                task.Status = TaskStatus.Expired;
            }
            taskRepository.UpDataRange(tasks);
        }
    }
}
