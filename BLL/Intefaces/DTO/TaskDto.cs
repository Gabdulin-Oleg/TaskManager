using DAL.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
namespace BL.Intefaces.DTO
{
    public class TaskDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название задачи
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Время создания задачи
        /// </summary>
        public DateTime TaskCreateDate { get; set; }
        /// <summary>
        /// Теги
        /// </summary>
        public string Tegs { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Дата завершения задачи
        /// </summary>
        public DateTime TaskComplatedDate { get; set; }
        /// <summary>
        /// Статус задачи
        /// </summary>
        public TaskStatus Status { get; set; }
    }
}
