using INDWalks.Models.Domain;
using INDWalks.Models.DTOs;

namespace INDWalks.Repositories
{
    public interface IWalksRepository
    {
        Task<Walks>CreateAsyc(Walks walks);

        Task<Walks?> DeleteWalkAsync(Guid id);

        Task<List<Walks>> GetAllAsync(string? filterOn = null, string? filterquery = null);

        Task<Walks?> GetbyIdAsync(Guid id);

        Task<Walks?> UpdateWalkAsync(Guid id, Walks walk);
    }   
}
