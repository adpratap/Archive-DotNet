using Archive.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Archive.Data
{
    public class ArchiveDbContext : DbContext
    {
        public ArchiveDbContext(DbContextOptions options) : base(options) { 
        }

        public DbSet<ArchiveModel> Archives { get; set; }
    }
}
