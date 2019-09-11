using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public class BdContext :DbContext
    {
        public BdContext(DbContextOptions<BdContext> options) : base(options)
        {

        }
        public DbSet<Tarea> Tareas { get; set; }
    }
}