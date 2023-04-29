using System.ComponentModel.DataAnnotations;

namespace APP.DTO
{
    public class PersonalInfoDTO
    {
		public IFormFile FileDetails { get; set; }
		public int Id { get; init; }
		[StringLength(100)]
		public string Name { get; set; } = null!;
		public DateTime DoB { get; set; }
		[StringLength(100)]
		public string? Address { get; set; } = null!;
		[StringLength(50)]
		public string? Email { get; set; } = null!;
		[StringLength(13)]
		public string Phone { get; set; } = null!;

		[StringLength(10)]
		public string? MaritalStatus { get; set; } = null!;
		
	}
}
