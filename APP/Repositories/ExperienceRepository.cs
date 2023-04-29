using APP.Context;
using APP.DTO;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using APP.Model;

namespace APP.Repositories
{
    public class ExperienceRepository : IExperienceRepository
    {
        private IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public ExperienceRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Experience>> GetAllAsync()
        {
            return await _context.Experience.Include(e => e.Company).ToListAsync();
        }

        public async Task<Experience> GetByIdAsync(int id)
        {
            return await _context.Experience.Include(e => e.Company).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(ExperienceDTO Experience)
        {
            var pro = _mapper.Map<Experience>(Experience);
            await _context.Experience.AddAsync(pro);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ExperienceDTO Experience)
        {
            _context.Entry(Experience).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Experience = await _context.Experience.FindAsync(id);
            _context.Experience.Remove(Experience);
            await _context.SaveChangesAsync();
        }
    }
    public interface IExperienceRepository
    {
        Task<IEnumerable<Experience>> GetAllAsync();
        Task<Experience> GetByIdAsync(int id);
        Task AddAsync(ExperienceDTO Experience);
        Task UpdateAsync(ExperienceDTO Experience);
        Task DeleteAsync(int id);
    }
}
