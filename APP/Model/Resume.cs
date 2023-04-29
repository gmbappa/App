using System.ComponentModel.DataAnnotations;

namespace APP.Model
{
    public class Resume
    {
        [Key]
        public int Id { get; init; }
        [StringLength(100)]
        public string Name { get; set; } = null!;
        public byte[] FileData { get; set; } = null!;        
    }
}
