using Microsoft.AspNetCore.Mvc;
using REST_API_Task.Controllers;
using REST_API_Task.Models;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace REST_API_Task.Tests
{
    public class DogsControllerTests
    {
        [Fact]
        public async Task GetDogs_Test_Correct_Response()
        {
            var _context = DbContextMocker.GetDogsDbContext(nameof(GetDogs_Test_Correct_Response));
            var _controller = new DogsController(_context);

            var response = await _controller.GetDogs("name", "asc", 1, 2);

            var itemsCount = 0;

            if (response.Value != null)
                itemsCount = response.Value.Count();

            Assert.NotNull(response);
            Assert.Equal(2, itemsCount);
        }

        [Fact]
        public async Task GetDog_Test_Correct_Response()
        {
            var _context = DbContextMocker.GetDogsDbContext(nameof(GetDog_Test_Correct_Response));
            var _controller = new DogsController(_context);

            var response = await _controller.GetDog("Neo");

            var correctDog = new Dog
            {
                Name = "Neo",
                Color = "red & amber",
                TailLength = 22,
                Weight = 32
            };

            Assert.NotNull(response);
            Assert.Equal(correctDog.Name, response.Value.Name);
            Assert.Equal(correctDog.Color, response.Value.Color);
            Assert.Equal(correctDog.TailLength, response.Value.TailLength);
            Assert.Equal(correctDog.Weight, response.Value.Weight);
        }

        [Fact]
        public async Task PostDog_Test_Correct_Response()
        {
            var _context = DbContextMocker.GetDogsDbContext(nameof(PostDog_Test_Correct_Response));
            var _controller = new DogsController(_context);

            var dog = new Dog
            {
                Name = "Doggy",
                Color = "brown",
                TailLength = 12,
                Weight = 34
            };

            var response = await _controller.PostDog(dog);

            var result = response.Result as ObjectResult;

            Assert.NotNull(response);
            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
            Assert.Equal(dog, result.Value);
        }
    }
}
