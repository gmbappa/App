using System.ComponentModel.DataAnnotations;

namespace APP.DTO
{
    public class EducationDTO
    {
        [Key]
        public int Id { get; init; }
        [StringLength(50)]
        public string Year { get; set; } = null!;
        [StringLength(100)]
        public string Degree { get; set; } = null!;
        [StringLength(100)]
        public string Institute { get; set; } = null!;
    }
}
