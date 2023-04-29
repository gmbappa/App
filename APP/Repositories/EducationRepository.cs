
using APP.Context;
using APP.DTO;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using APP.Model;

namespace APP.Repositories
{
    public class EducationRepository : IEducationRepository
    {
        private IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public EducationRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Education>> GetAllAsync()
        {
            return await _context.Education.ToListAsync();
        }

        public async Task<Education> GetByIdAsync(int id)
        {
            return await _context.Education.FindAsync(id);
        }

        public async Task AddAsync(EducationDTO Education)
        {
            var pro = _mapper.Map<Education>(Education);
            await _context.Education.AddAsync(pro);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EducationDTO Education)
        {
            _context.Entry(Education).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Education = await _context.Education.FindAsync(id);
            _context.Education.Remove(Education);
            await _context.SaveChangesAsync();
        }
    }
    public interface IEducationRepository
    {
        Task<IEnumerable<Education>> GetAllAsync();
        Task<Education> GetByIdAsync(int id);
        Task AddAsync(EducationDTO Education);
        Task UpdateAsync(EducationDTO Education);
        Task DeleteAsync(int id);
    }
}
