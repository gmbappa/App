using APP.DTO;
using APP.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty PersonalInfos, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInfoController : ControllerBase
    {
        private readonly IPersonalInfoRepository _PersonalInfoRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PersonalInfoController(IPersonalInfoRepository PersonalInfoRepository, IWebHostEnvironment webHostEnvironment)
        {
            _PersonalInfoRepository = PersonalInfoRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalInfoDTO>>> GetAllPersonalInfos()
        {
            var PersonalInfo = await _PersonalInfoRepository.GetAllAsync();
            return Ok(PersonalInfo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalInfoDTO>> GetPersonalInfoById(int id)
        {
            var PersonalInfo = await _PersonalInfoRepository.GetByIdAsync(id);
            if (PersonalInfo == null)
            {
                return NotFound();
            }
            return Ok(PersonalInfo);
        }

        [HttpPost]
        public async Task<ActionResult> AddPersonalInfo([FromForm] PersonalInfoDTO req)      
        {
            if (req.FileDetails == null || req.FileDetails.Length == 0)
                return BadRequest("No file was selected.");
            var fileExtension = Path.GetExtension(req.FileDetails.FileName);

            if (!new[] { ".jpg", ".jpeg", ".png", ".gif" }.Contains(fileExtension))
                return BadRequest("Invalid file type. Only JPG, JPEG, PNG and GIF are allowed.");


            await _PersonalInfoRepository.AddAsync(req);
            var info=  await _PersonalInfoRepository.GetByInfoAsync(req);


            var folderName = Path.Combine("Resources", "Images");
            var uploadsFolder = Path.Combine(_webHostEnvironment.ContentRootPath, folderName);

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName = info.Id + fileExtension;
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await req.FileDetails.CopyToAsync(fileStream);
            }

            return Ok(req);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePersonalInfo(int id,[FromForm] PersonalInfoDTO req)
        {   
            if (id != req.Id)
            {
                return BadRequest();
            }

            if (req.FileDetails == null || req.FileDetails.Length == 0)
                return BadRequest("No file was selected.");
            var fileExtension = Path.GetExtension(req.FileDetails.FileName);

            if (!new[] { ".jpg", ".jpeg", ".png", ".gif" }.Contains(fileExtension))
                return BadRequest("Invalid file type. Only JPG, JPEG, PNG and GIF are allowed.");

            await _PersonalInfoRepository.UpdateAsync(req);

            var folderName = Path.Combine("Resources", "Images");
            var uploadsFolder = Path.Combine(_webHostEnvironment.ContentRootPath, folderName);

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName = id + fileExtension;
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await req.FileDetails.CopyToAsync(fileStream);
            }
            return Ok(req);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePersonalInfo(int id)
        {
            var PersonalInfo = await _PersonalInfoRepository.GetByIdAsync(id);
            if (PersonalInfo == null)
            {
                return NotFound();
            }
            await _PersonalInfoRepository.DeleteAsync(id);
            return Ok(PersonalInfo);
        }
    }
}

