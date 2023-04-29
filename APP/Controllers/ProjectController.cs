using APP.DTO;
using APP.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetAllProjects()
        {
            var project = await _projectRepository.GetAllAsync();
             return Ok(project);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDTO>> GetProjectById(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDTO>> AddProject(ProjectDTO project)
        {
            await _projectRepository.AddAsync(project);
            return Ok(project);           
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProject(int id, ProjectDTO project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }
            await _projectRepository.UpdateAsync(project);
            return Ok(project);            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            await _projectRepository.DeleteAsync(id);
            return Ok(project);                      
        }
    }
}