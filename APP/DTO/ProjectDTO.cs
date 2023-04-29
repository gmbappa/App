using System.ComponentModel.DataAnnotations;

namespace APP.DTO
{
    public class ProjectDTO
    {
        public int Id { get; init; }
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [StringLength(500)]
        public string Description { get; set; } = null!;
        [StringLength(500)]
        public string Technologies { get; set; } = null!;
    }
}
