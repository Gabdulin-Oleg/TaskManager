using BL.Intefaces.DTO;
using DAL.Entitis;
using System.Collections.Generic;

namespace BL.Intefaces
{
    public interface ITaskManageService
    {
        /// <summary>
        /// создание задачи
        /// </summary>
        /// <param name="taskDto">ДТО задачи</param>
        /// <returns>готовая задача</returns>
        TaskDto CreateTask(TaskDto taskDto);
        /// <summary>
        /// получение задачи по Id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Задачу</returns>
        TaskDto GetTaskById(int id);
        /// <summary>
        /// получене задач по фильтру
        /// </summary>
        /// <param name="filter">филтр задачи</param>
        /// <returns>Задачи отфильтрованные по фильтру (если ровно null то возвращает все задачи)</returns>
        ICollection<TaskDto> GetTasksByFiltred(string filter);
        /// <summary>
        /// обновлене задачи
        /// </summary>
        /// <param name="taskDto">ДТО задачи</param>
        /// <returns>Обновленую задачу</returns>
        TaskDto UpDate(TaskDto taskDto);
        /// <summary>
        /// Проверка статуса задачи (если просрочена меняет статус на Expired)
        /// </summary>
        public IEnumerable<Task> CheckingDelinquency(IEnumerable<Task> tasks);
    }
}