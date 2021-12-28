using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API_Task.Data;
using REST_API_Task.Models;

namespace REST_API_Task.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public DogsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dog>>> GetDogs(string? attribute, string? order, int? page, int? pageSize)
        {
            IQueryable<Dog> dogsQuery = _context.Dogs;

            // Base values in case of "null" for attributes
            if (page == null)
                page = 0;

            if (pageSize == null)
                pageSize = 0;

            if (attribute == null)
                attribute = "name";

            if (order == null)
                order = "asc";

            if (attribute != null)
            {
                switch (attribute)
                {
                    case "name":
                        if (order == "asc")
                            dogsQuery = dogsQuery.OrderBy(dog => dog.Name);
                        else
                            dogsQuery = dogsQuery.OrderByDescending(dog => dog.Name);

                        break;
                    case "color":
                        if (order == "asc")
                            dogsQuery = dogsQuery.OrderBy(dog => dog.Color);
                        else
                            dogsQuery = dogsQuery.OrderByDescending(dog => dog.Color);

                        break;
                    case "tailLength":
                        if (order == "asc")
                            dogsQuery = dogsQuery.OrderBy(dog => dog.TailLength);
                        else
                            dogsQuery = dogsQuery.OrderByDescending(dog => dog.TailLength);

                        break;
                    case "weight":
                        if (order == "asc")
                            dogsQuery = dogsQuery.OrderBy(dog => dog.Weight);
                        else
                            dogsQuery = dogsQuery.OrderByDescending(dog => dog.Weight);

                        break;
                    default:
                        return BadRequest();
                }
            }

            // Returning certain page with certain pageSize
            if (page != 0 && pageSize != 0)
                return await dogsQuery.Skip(((int)page - 1) * (int)pageSize).Take((int)pageSize).ToListAsync();

            // Returning certain pageSize (amount of elements) based on order set
            if (pageSize != 0)
                return await dogsQuery.Take((int)pageSize).ToListAsync();

            return await dogsQuery.ToListAsync();
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Dog>> GetDog(string name)
        {
            var dog = await _context.Dogs.FindAsync(name);

            if (dog == null)
            {
                return NotFound();
            }

            return dog;
        }

        [HttpPost]
        public async Task<ActionResult<Dog>> PostDog(Dog dog)
        {
            if (dog.TailLength <= 0 || dog.Weight <= 0)
                return BadRequest();

            _context.Dogs.Add(dog);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DogExists(dog.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDog", new { name = dog.Name }, dog);
        }

        private bool DogExists(string name)
        {
            return _context.Dogs.Any(dog => dog.Name == name);
        }
    }
}
