using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class TaskViewModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        [Required]
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
        [Required]
        [StringLength(2048)]
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        [Required]
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
