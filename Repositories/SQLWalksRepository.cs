using INDWalks.Data;
using INDWalks.Models.Domain;
using INDWalks.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace INDWalks.Repositories
{
    public class SQLWalksRepository : IWalksRepository
    {
        private readonly INDWalksDbContext dbContext;

        public SQLWalksRepository(INDWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Walks> CreateAsyc(Walks walks)
        {
            await dbContext.Walks.AddAsync(walks);
            await dbContext.SaveChangesAsync();
            return walks;
        }

        public async Task<Walks?> DeleteWalkAsync(Guid id)
        {
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk == null)
            {
                return null;
            }
            dbContext.Walks.Remove(existingWalk);
            await dbContext.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<List<Walks>> GetAllAsync(string? filterOn = null, string? filterquery = null, string? sortby = null, bool? isAscending = true, int pagenumber = 1, int pagesize = 5)
        {
            var walk = dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();

            //Filtering
            if (!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterquery))
            { 
                switch (filterOn.ToLower())
                {
                    case "region":
                        walk = walk.Where(x => x.Region.Name.Contains(filterquery));
                        break;
                    case "difficulty":
                        walk = walk.Where(x => x.Difficulty.Name.Contains(filterquery));
                        break;
                    default:
                        break;
                }
            }

            //Sorting
            if (!string.IsNullOrWhiteSpace(sortby))
            {
                    switch(sortby.ToLower())
                    {
                        case "name":
                            walk = isAscending ?? true ? walk.OrderBy(x => x.Name) : walk.OrderByDescending(x=> x.Name);
                            break;
                        case "length":
                            walk = isAscending ?? true ? walk.OrderBy(x => x.LengthInKm): walk.OrderByDescending(x=> x.LengthInKm);
                            break;
                        case"region":
                            walk = isAscending ?? true ? walk.OrderBy(x => x.Region.Name): walk.OrderByDescending(x=> x.Region.Name);
                            break;
                        case "difficulty":
                            walk = isAscending ?? true ? walk.OrderBy(x => x.Difficulty.Name): walk.OrderByDescending(x => x.Difficulty.Name);
                            break;
                        default:
                            break;
                    }
                
               
            }

            // pagination

            int skipResult = (pagenumber - 1) * pagesize;

            return await walk.Skip(skipResult).Take(pagesize).ToListAsync();
        }

        public async Task<Walks?> GetbyIdAsync(Guid id)
        {
            
            return await dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walks?> UpdateWalkAsync(Guid id, Walks walk)
        {
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if(existingWalk == null)
            {
                return null;
            }

            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId = walk.RegionId;

            await dbContext.SaveChangesAsync();
            return existingWalk;

        }
    }
}
