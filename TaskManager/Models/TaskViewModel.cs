using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class TaskViewModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название задачи
        /// </summary>        
        [Required]
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
        [Required]
        [StringLength(2048)]
        public string Description { get; set; }
        /// <summary>
        /// Дата завершения задачи
        /// </summary>
        [Required]
        public DateTime TaskComplatedDate { get; set; }
        /// <summary>
        /// Статус задачи
        /// </summary>
        public TaskStatus Status { get; set; }
    }
}
