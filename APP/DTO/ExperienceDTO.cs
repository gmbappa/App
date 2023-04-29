using APP.Model;
using System.ComponentModel.DataAnnotations;

namespace APP.DTO
{
    public class ExperienceDTO
    {
		public int Id { get; init; }
		[StringLength(50)]
		public string Designation { get; set; } = null!;
		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		[StringLength(1000)]
		public string Responsibilities { get; set; } = null!;

		public int CompanyId { get; set; }
		public Company Company { get; set; } = null!;
	}
}
