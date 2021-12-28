using Microsoft.EntityFrameworkCore;
using REST_API_Task.Models;

namespace REST_API_Task.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext (DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Dog> Dogs { get; set; }
    }
}
