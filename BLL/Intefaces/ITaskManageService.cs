using BL.Intefaces.DTO;
using System.Collections.Generic;

namespace BL.Intefaces
{
    public interface ITaskManageService
    {
        /// <summary>
        /// создание задачи
        /// </summary>
        /// <param name="taskDto"></param>
        TaskDto CreateTask(TaskDto taskDto);
        /// <summary>
        /// получение задачи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TaskDto GetTaskById(int id);
        /// <summary>
        /// получене задачь по списку
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        ICollection<TaskDto> GetTasksByFiltred(string filter);
        /// <summary>
        /// обновлене задачи
        /// </summary>
        /// <param name="taskDto"></param>
        TaskDto UpDate(TaskDto taskDto);
        public void ChecStatus();
    }
}