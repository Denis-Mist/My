using Microsoft.EntityFrameworkCore;
using MyApi.Hobbys;

namespace MyApi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<MyModel> MyModels { get; set; }
        public DbSet<Hobby> Hobbys { get; set; } // Добавлено для работы с хобби
    }
}
