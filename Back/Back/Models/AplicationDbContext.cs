using Microsoft.EntityFrameworkCore;

namespace Back.Models
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
        {

        }

        public DbSet<Pet> Pets { get; set; }
    }
}
