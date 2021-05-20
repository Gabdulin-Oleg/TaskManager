using DAL.Entitis;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface ITaskRepository
    {
        /// <summary>
        /// Создание задачи
        /// </summary>
        /// <param name="task"></param>
        void Create(Task task);
        /// <summary>
        /// Измениние задачи
        /// </summary>
        /// <param name="task"></param>
        void UpData(Task task);
        /// <summary>
        /// Получение всех задач
        /// </summary>
        ICollection<Task> GetAllTask();
        /// <summary>
        /// получение задачи по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task FindById(int id);
        /// <summary>
        /// Изменения нескольких задач
        /// </summary>
        /// <param name="task"></param>
        public void UpDataRange(IEnumerable<Task> task);
    }
}
