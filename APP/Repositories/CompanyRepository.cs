using APP.Context;
using APP.DTO;
using APP.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APP.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _context.Company.ToListAsync();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _context.Company.FindAsync(id);
        }

        public async Task AddAsync(CompanyDTO company)
        {
            var req = _mapper.Map<Company>(company);
            _context.Company.Add(req);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CompanyDTO company)
        {
            _context.Entry(company).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var company = await _context.Company.FindAsync(id);
            if (company != null)
            {
                _context.Company.Remove(company);
                await _context.SaveChangesAsync();
            }
        }
    }
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllAsync();
        Task<Company> GetByIdAsync(int id);
        Task AddAsync(CompanyDTO company);
        Task UpdateAsync(CompanyDTO company);
        Task DeleteAsync(int id);
    }
}