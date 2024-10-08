using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MyApi.Models;
using MyApi.Hobbys;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MyController(ApplicationDbContext context)
        {
            _context = context;

            // Создание базы данных, если она не существует
            _context.Database.EnsureCreated();
        }

        [HttpPost("hobby")]
        public async Task<IActionResult> CreateHobby([FromBody] Hobby model)
        {
            if (model == null)
            {
                return BadRequest("Model cannot be null");
            }

            await _context.Hobbys.AddAsync(model); // Используем один контекст
            await _context.SaveChangesAsync();

            return Ok(model);
        }

        [HttpPost("user")]
        public async Task<IActionResult> Create([FromBody] MyModel model)
        {
            if (model == null)
            {
                return BadRequest("Model cannot be null");
            }

            await _context.MyModels.AddAsync(model);
            await _context.SaveChangesAsync();

            return Ok(model);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var model = await _context.MyModels.FindAsync(id);

            if (model == null)
            {
                return NotFound($"Model with id {id} not found.");
            }

            return Ok(model);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var model = await _context.MyModels.FirstOrDefaultAsync(m => m.Name == name);

            if (model == null)
            {
                return NotFound($"Model with name '{name}' not found.");
            }

            return Ok(model);
        }
    }
}
