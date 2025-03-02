using INDWalks.Data;
using INDWalks.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace INDWalks.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly INDWalksDbContext dbContext;

        public SQLRegionRepository(INDWalksDbContext dbContext)
        {
            this.dbContext = dbContext;   
        }

        public async Task<Regions> CreateRegionsAsync(Regions regions)
        {
            await dbContext.Regions.AddAsync(regions);
            await dbContext.SaveChangesAsync();
            return regions;
        }

        public async Task<Regions?> DeleteRegionAsync(Guid id)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x=> x.Id == id);
            if(existingRegion == null)
            {
                return null;
            }

            dbContext.Regions.Remove(existingRegion);
            await dbContext.SaveChangesAsync();
            return existingRegion;

        }

        public async Task<List<Regions>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Regions?> GetbyIdAsync(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
   
        }

        public async Task<Regions?> UpdateRegionsAsync(Guid id, Regions regions)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            
            if(existingRegion == null)
            {
                return null;
            }

            existingRegion.Name = regions.Name;
            existingRegion.Code = regions.Code;
            existingRegion.RegionImageUrl = regions.RegionImageUrl;

            await dbContext.SaveChangesAsync();
            return existingRegion;
            

        }
    }
}
