using APP.Model;
using Microsoft.EntityFrameworkCore;

namespace APP.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions option) : base(option)
        {
        }
        public DbSet<PersonalInfo> PersonalInfo { get; set; } = null!;
        public DbSet<Resume> Resume { get; set; } = null!;
        public DbSet<Experience> Experience { get; set; } = null!;
        public DbSet<Company> Company { get; set; } = null!;
        public DbSet<Project> Project { get; set; } = null!;
        public DbSet<Education> Education { get; set; } = null!;
    }
}
