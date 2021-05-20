using DAL.Entitis;
using Microsoft.EntityFrameworkCore;

namespace DAL.DBContext
{
    public class AppDBContext : DbContext
    {
        DbSet<Task> Tasks { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
    }
}
