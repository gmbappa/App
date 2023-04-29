using APP.DTO;
using APP.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceRepository _ExperienceRepository;

        public ExperienceController(IExperienceRepository ExperienceRepository)
        {
            _ExperienceRepository = ExperienceRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExperienceDTO>>> GetAllExperiences()
        {
            var Experience = await _ExperienceRepository.GetAllAsync();
             return Ok(Experience);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExperienceDTO>> GetExperienceById(int id)
        {
            var Experience = await _ExperienceRepository.GetByIdAsync(id);
            if (Experience == null)
            {
                return NotFound();
            }
            return Ok(Experience);
        }

        [HttpPost]
        public async Task<ActionResult<ExperienceDTO>> AddExperience(ExperienceDTO Experience)
        {
            await _ExperienceRepository.AddAsync(Experience);
            return Ok(Experience);           
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateExperience(int id, ExperienceDTO Experience)
        {
            if (id != Experience.Id)
            {
                return BadRequest();
            }
            await _ExperienceRepository.UpdateAsync(Experience);
            return Ok(Experience);            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExperience(int id)
        {
            var Experience = await _ExperienceRepository.GetByIdAsync(id);
            if (Experience == null)
            {
                return NotFound();
            }
            await _ExperienceRepository.DeleteAsync(id);
            return Ok(Experience);                      
        }
    }
}