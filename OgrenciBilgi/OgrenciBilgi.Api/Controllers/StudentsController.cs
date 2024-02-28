using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OgrenciBilgi.Api.Data;
using OgrenciBilgi.Api.Data.Entities;

namespace OgrenciBilgi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly DataBaseContext _dbContext;

        public StudentsController(DataBaseContext context)
        {
            _dbContext = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _dbContext.Students
                .ToListAsync();
            return Ok(students);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(x=>x.Id==id);
            if (student is null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Post([FromForm] StudentEntity student)
        {
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = student.Id });
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] StudentEntity student)
        {
            if (id!=student.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(student).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            if (student is null)
            {
                return NotFound();
            }
            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
