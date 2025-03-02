using AutoMapper;
using INDWalks.Models.Domain;
using INDWalks.Models.DTOs;

namespace INDWalks.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap <Regions,RegionsDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Regions>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Regions>().ReverseMap();
            CreateMap<WalksRequestDTO, Walks>().ReverseMap();
            CreateMap<Walks, WalksDto>().ReverseMap();
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
            CreateMap<UpdateWalkRequestDTO, Walks>().ReverseMap();

        }
    }
}
