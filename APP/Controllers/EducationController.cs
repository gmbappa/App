using APP.DTO;
using APP.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EducationController : ControllerBase
    {
        private readonly IEducationRepository _EducationRepository;

        public EducationController(IEducationRepository EducationRepository)
        {
            _EducationRepository = EducationRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EducationDTO>>> GetAllEducations()
        {
            var Education = await _EducationRepository.GetAllAsync();
             return Ok(Education);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EducationDTO>> GetEducationById(int id)
        {
            var Education = await _EducationRepository.GetByIdAsync(id);
            if (Education == null)
            {
                return NotFound();
            }
            return Ok(Education);
        }

        [HttpPost]
        public async Task<ActionResult<EducationDTO>> AddEducation(EducationDTO Education)
        {
            await _EducationRepository.AddAsync(Education);
            return Ok(Education);           
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEducation(int id, EducationDTO Education)
        {
            if (id != Education.Id)
            {
                return BadRequest();
            }
            await _EducationRepository.UpdateAsync(Education);
            return Ok(Education);            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEducation(int id)
        {
            var Education = await _EducationRepository.GetByIdAsync(id);
            if (Education == null)
            {
                return NotFound();
            }
            await _EducationRepository.DeleteAsync(id);
            return Ok(Education);                      
        }
    }
}