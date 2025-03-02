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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for difficulties
            // Easy , Medium, Hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("c9a4a37f-6f4d-4e3b-b0e7-a928bb4bf87b"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id =  Guid.Parse("4c04209b-8490-41f7-a97f-dd68618c6307"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id =  Guid.Parse("092600b8-e6ff-4bc5-b762-4b2f494a8510"),
                    Name = "Hard"
                }
            };


            // Seed difficulties to DB
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for regions

            var regions = new List<Regions>()
            {
                new Regions()
                {
                    Id = Guid.Parse("1469cb3d-71fe-4133-a5ad-a466cc004edc"),
                    Code = "BR",
                    Name = "Bihar",
                    RegionImageUrl = "Bihar-state.jpg"
                },

                new Regions()
                {
                    Id = Guid.Parse("ebd40265-3712-42bc-9171-4808c250533a"),
                    Code = "DL",
                    Name = "New Delhi",
                    RegionImageUrl = "New-Delhi-state.jpg"
                },

                new Regions()
                {
                    Id = Guid.Parse("f85a8f88-a975-47f9-9f88-fcd6ddf9b4de"),
                    Code = "MH",
                    Name = "Maharastra",
                    RegionImageUrl = "Maharastra-state.jpg"
                },

                new Regions()
                {
                    Id = Guid.Parse("6a618c79-d331-49cd-a5f6-1a1e92fcc2bb"),
                    Code = "WB",
                    Name = "West-Bengal",
                    RegionImageUrl = ""
                },

                new Regions()
                {
                    Id = Guid.Parse("a7c091ca-79d7-47a8-b3f9-bb2b74155f56"),
                    Code = "TN",
                    Name = "Tamil Nadu",
                    RegionImageUrl = "Tamil-Nadu-state.jpg"
                },
            };
            modelBuilder.Entity<Regions>().HasData(regions);
        }
    }
}
