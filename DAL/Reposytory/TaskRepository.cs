using DAL.DBContext;
using DAL.Entitis;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Reposytory
{
    public class TaskRepository : ITaskRepository
    {
        AppDBContext AppDBContext;

        public TaskRepository(AppDBContext appDBContext)
        {
            AppDBContext = appDBContext;
        }

        public void Create(Task task)
        {
            AppDBContext.Set<Task>().Add(task);
            AppDBContext.SaveChanges();
        }
        public Task FindById(int id)
        {
            return AppDBContext.Set<Task>().FirstOrDefault(p => p.Id == id);
        }   

        public ICollection<Task> GetAllTask()
        {
            return AppDBContext.Set<Task>().ToList();
        }

        public void UpData(Task task)
        {
            AppDBContext.Set<Task>().Update(task);
            AppDBContext.SaveChanges();
        }
        public void UpDataRange(IEnumerable<Task> task)
        {
            
            AppDBContext.Set<Task>().UpdateRange(task);
            AppDBContext.SaveChanges();
        }
    }
}
