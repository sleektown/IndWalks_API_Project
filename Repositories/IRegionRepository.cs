using INDWalks.Models.Domain;

namespace INDWalks.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Regions>> GetAllAsync();

        Task<Regions?> GetbyIdAsync(Guid id);

        Task<Regions> CreateRegionsAsync(Regions regions);


        Task<Regions?> UpdateRegionsAsync(Guid id, Regions regions);

        Task<Regions?> DeleteRegionAsync(Guid id);


    }
}
