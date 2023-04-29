using System.ComponentModel.DataAnnotations;

namespace APP.Model
{
    public class Company
    {
        [Key]
        public int Id { get; init; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [StringLength(100)]
        public string Location { get; set; }=null!;
    }
}
