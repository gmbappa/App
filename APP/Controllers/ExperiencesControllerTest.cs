using APP.Context;
using APP.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APP.Controllers
{
    [ApiController]
    [Route("api/Experience")]
    public class ExperienceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExperienceController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Experience>>> GetExperience()
        {
            var Experience = await _context.Experience.Include(e => e.Company).ToListAsync();
            return Ok(Experience);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Experience>> GetExperienceById(int id)
        {
            var experience = await _context.Experience.Include(e => e.Company).FirstOrDefaultAsync(e => e.Id == id);
            if (experience == null)
            {
                return NotFound();
            }
            return Ok(experience);
        }

        [HttpPost]
        public async Task<ActionResult<Experience>> CreateExperience(Experience experience)
        {
            _context.Experience.Add(experience);
            await _context.SaveChangesAsync();
            return Ok(experience);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Experience>> UpdateExperience(int id, Experience experience)
        {
            if (id != experience.Id)
            {
                return BadRequest();
            }

            _context.Entry(experience).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(experience);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Experience>> DeleteExperience(int id)
        {
            var experience = await _context.Experience.FindAsync(id);
            if (experience == null)
            {
                return NotFound();
            }

            _context.Experience.Remove(experience);
            await _context.SaveChangesAsync();
            return Ok(experience);
        }
    }

}
