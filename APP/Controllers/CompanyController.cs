using APP.Context;
using APP.DTO;
using APP.Model;
using APP.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APP.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _repo;

        public CompaniesController(ICompanyRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetCompanies()
        {
            var companies = await _repo.GetAllAsync();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDTO>> GetCompanyById(int id)
        {
            var company = await _repo.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult<CompanyDTO>> AddCompany(CompanyDTO company)
        {
            await _repo.AddAsync(company);           
            return Ok(company);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyDTO>> UpdateCompany(int id, CompanyDTO company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }                       
            await _repo.UpdateAsync(company);
            return Ok(company);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CompanyDTO>> DeleteCompany(int id)
        {
            var company = await _repo.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }        
            await _repo.DeleteAsync(id);
            return Ok(company);
        }
    }

}