using Microsoft.EntityFrameworkCore;
using REST_API_Task.Data;

namespace REST_API_Task.Tests
{
    public static class DbContextMocker
    {
        public static ApplicationContext GetDogsDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: dbName).Options;

            var dbContext = new ApplicationContext(options);

            dbContext.Seed();

            return dbContext;
        }
    }
}
