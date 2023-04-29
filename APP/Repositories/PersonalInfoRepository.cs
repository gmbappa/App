using APP.Context;
using APP.DTO;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using APP.Model;

namespace APP.Repositories
{
    public class PersonalInfoRepository : IPersonalInfoRepository
    {
        private IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public PersonalInfoRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonalInfo>> GetAllAsync()
        {
            return await _context.PersonalInfo.ToListAsync();
        }

        public async Task<PersonalInfo> GetByIdAsync(int id)
        {
            return await _context.PersonalInfo.FindAsync(id);
        }

        public async Task<PersonalInfo> GetByInfoAsync(PersonalInfoDTO info)
        {
            return await _context.PersonalInfo.Where(x=>x.Name==info.Name && x.Phone==info.Phone).FirstOrDefaultAsync();
        }

        public async Task AddAsync(PersonalInfoDTO PersonalInfo)
        {
            var pro = _mapper.Map<PersonalInfo>(PersonalInfo);
            await _context.PersonalInfo.AddAsync(pro);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PersonalInfoDTO PersonalInfo)
        {
            _context.Entry(PersonalInfo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var PersonalInfo = await _context.PersonalInfo.FindAsync(id);
            _context.PersonalInfo.Remove(PersonalInfo);
            await _context.SaveChangesAsync();
        }
    }
    public interface IPersonalInfoRepository
    {
        Task<IEnumerable<PersonalInfo>> GetAllAsync();
        Task<PersonalInfo> GetByIdAsync(int id);
        Task<PersonalInfo> GetByInfoAsync(PersonalInfoDTO info);
        Task AddAsync(PersonalInfoDTO PersonalInfo);
        Task UpdateAsync(PersonalInfoDTO PersonalInfo);
        Task DeleteAsync(int id);
    }
}
