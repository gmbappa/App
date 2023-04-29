using System.ComponentModel.DataAnnotations;

namespace APP.Model
{
    public class Education
    {
        
        public int Id { get; init; }
        [StringLength(50)]
        public string Year { get; set; } = null!;
        [StringLength(100)]
        public string Degree { get; set; } = null!;
        [StringLength(100)]
        public string Institute { get; set; } = null!;
    }
}
