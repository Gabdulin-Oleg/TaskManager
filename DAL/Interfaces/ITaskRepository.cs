using DAL.Entitis;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface ITaskRepository
    {

        /// <summary>
        /// Создание задачи
        /// </summary>
        /// <param name="task">модель задачи</param>
        void Create(Task task);
        /// <summary>
        /// Измениние задачи
        /// </summary>
        /// <param name="task">модель задачи</param>
        void UpData(Task task);
        /// <summary>
        /// Получение всех задач
        /// </summary>
        /// <returns>список задач</returns>
        ICollection<Task> GetAllTask();
        /// <summary>
        /// получение задачи по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Модель задачи</returns>
        public Task FindById(int id);
        /// <summary>
        /// Изменения нескольких задач
        /// </summary>
        /// <param name="task">модель задачи</param>
        public void UpDataRange(IEnumerable<Task> task);
    }
}
