using REST_API_Task.Data;
using REST_API_Task.Models;

namespace REST_API_Task.Tests
{
    public static class DbContextExtensions
    {
        public static void Seed(this ApplicationContext dbContext)
        {
            dbContext.Dogs.AddRange(
                    new Dog
                    {
                        Name = "Neo",
                        Color = "red & amber",
                        TailLength = 22,
                        Weight = 32
                    },

                    new Dog
                    {
                        Name = "Jessy",
                        Color = "white & black",
                        TailLength = 7,
                        Weight = 14
                    }
                );

            dbContext.SaveChanges();
        }
    }
}
