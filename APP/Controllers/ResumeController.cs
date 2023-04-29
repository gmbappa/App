using APP.DTO;
using APP.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        private readonly IResumeRepository _repo;

        public ResumeController(IResumeRepository repo)
        {
            _repo = repo;
        }       
        [HttpPost("AddResume")]
        public async Task<ActionResult> AddResume([FromForm] ResumeDTO ResumeDetails)
        {
            if (ResumeDetails == null)
            {
                return BadRequest();
            }
            try
            {
                await _repo.AddResume(ResumeDetails.FileDetails);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }      
        [HttpPost("AddMultipleResumeAsync")]
        public async Task<ActionResult> AddMultipleResumeAsync([FromForm] List<ResumeDTO> ResumeDetails)
        {
            if (ResumeDetails == null)
            {
                return BadRequest();
            }
            try
            {
                await _repo.AddMultipleResumeAsync(ResumeDetails);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }       
        [HttpGet("DownloadResume")]
        public async Task<ActionResult> DownloadResume(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            try
            {
                await _repo.DownloadResumeById(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}