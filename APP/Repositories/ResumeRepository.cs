using APP.Context;
using APP.DTO;
using APP.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APP.Repositories
{
    public class ResumeRepository : IResumeRepository
    {
        private IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public ResumeRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddResume(IFormFile fileData)
        {
            try
            {
                var fileDetails = new Resume()
                {
                    Id = 0,
                    Name = fileData.FileName                                  
                };

                using (var stream = new MemoryStream())
                {
                    fileData.CopyTo(stream);
                    fileDetails.FileData = stream.ToArray();
                }

                var result = _context.Resume.Add(fileDetails);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task AddMultipleResumeAsync(List<ResumeDTO> fileData)
        {
            try
            {
                foreach (ResumeDTO file in fileData)
                {
                    var fileDetails = new Resume()
                    {
                        Id = 0,
                        Name = file.FileDetails.FileName                       
                    };

                    using (var stream = new MemoryStream())
                    {
                        file.FileDetails.CopyTo(stream);
                        fileDetails.FileData = stream.ToArray();
                    }

                    var result = _context.Resume.Add(fileDetails);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DownloadResumeById(int Id)
        {
            try
            {
                var file = _context.Resume.Where(x => x.Id == Id).FirstOrDefaultAsync();

                var content = new System.IO.MemoryStream(file.Result.FileData);
                var path = Path.Combine(
                   Directory.GetCurrentDirectory(), "Resources\\File",
                   file.Result.Name);

                await CopyStream(content, path);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CopyStream(Stream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }
    }
    public interface IResumeRepository
    {
        public Task AddResume(IFormFile fileData);
        public Task AddMultipleResumeAsync(List<ResumeDTO> fileData);
        public Task DownloadResumeById(int fileName);
    }
}