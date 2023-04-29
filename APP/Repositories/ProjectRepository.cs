using APP.Context;
using APP.DTO;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using APP.Model;

namespace APP.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Project.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await _context.Project.FindAsync(id);
        }

        public async Task AddAsync(ProjectDTO project)
        {
            var pro = _mapper.Map<Project>(project);
            await _context.Project.AddAsync(pro);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProjectDTO project)
        {
            _context.Entry(project).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var project = await _context.Project.FindAsync(id);
            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
        }
    }
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task AddAsync(ProjectDTO project);
        Task UpdateAsync(ProjectDTO project);
        Task DeleteAsync(int id);
    }
}
