using Microsoft.EntityFrameworkCore;
using REST_API_Task.Data;

namespace REST_API_Task.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationContext>>()))
            {

                if (context.Dogs.Any())
                {
                    return;
                }

                context.Dogs.AddRange(
                    new Dog
                    {
                        Name = "Neo",
                        Color = "red & amber",
                        TailLength = 22,
                        Weight = 32
                    },

                    new Dog
                    {
                        Name = "Jessy ",
                        Color = "white & black",
                        TailLength = 7,
                        Weight = 14
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
