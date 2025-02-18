using INDWalks.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace INDWalks.Data
{
    public class INDWalksDbContext : DbContext
    {
        public INDWalksDbContext(DbContextOptions dbContextOpt): base(dbContextOpt)
        {
                
        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Regions> Regions { get; set; }

        public DbSet<Walks> Walks { get; set; }


    }
}
