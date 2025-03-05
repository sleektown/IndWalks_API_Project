using AutoMapper;
<<<<<<< HEAD
using INDWalks.CustomActionValidations;
=======
using INDWalks.CustomActionFilters;
>>>>>>> b7c2fdf96445235eec9decdc0f44e996b4ba6c4e
using INDWalks.Data;
using INDWalks.Models.Domain;
using INDWalks.Models.DTOs;
using INDWalks.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace INDWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get data from DB - via Domain Models

            var regionsDomain = await regionRepository.GetAllAsync();


            //Map Domain Models to DTOs

            //var regionDTO = new List<RegionsDto>();
            //foreach(var region in regionsDomain)
            //{
            //    regionDTO.Add(new RegionsDto()
            //    {
            //        Id = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        RegionImageUrl = region.RegionImageUrl
            //    });
            //}

            var regionDTO = mapper.Map<List<RegionsDto>>(regionsDomain);

            // return DTOs 

            return Ok(regionDTO);
        }


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetRegionById([FromRoute]Guid id)
        {
            var regionDomain = await regionRepository.GetbyIdAsync(id);
            if(regionDomain == null)
            {
                return NotFound("No data found with this Id.");
            }

            //Map Domain Models to DTO

            //var regionDTO = new RegionsDto()
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageUrl = regionDomain.RegionImageUrl

            //}; 

            var regionDTO = mapper.Map<RegionsDto>(regionDomain);
            return Ok(regionDTO);
        }


        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateRegion([FromBody]AddRegionRequestDto addregionreqdto)
        {

            //if (!ModelState.IsValid)          // Model Validations
            //{
            //    return BadRequest(ModelState);
            //}
            // Map DTO to Domain

            //var regionDomain = new Regions
            //{
            //    Name = addregionreqdto.Name,
            //    Code = addregionreqdto.Code,
            //    RegionImageUrl = addregionreqdto.RegionImageUrl
            //};
            //else
            //{
                var regionDomain = mapper.Map<Regions>(addregionreqdto);

                // Use Domain Models to Create entry in Db.
                regionDomain = await regionRepository.CreateRegionsAsync(regionDomain);

                // Map Domain Model back to DTO

                //var regionDTO = new RegionsDto
                //{
                //    Id = regionDomain.Id,
                //    Name = regionDomain.Name,
                //    Code = regionDomain.Code,
                //    RegionImageUrl = regionDomain.RegionImageUrl

                //};

                var regionDTO = mapper.Map<RegionsDto>(regionDomain);

                return CreatedAtAction(nameof(GetRegionById), new { id = regionDTO.Id }, regionDTO);
            //}
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateregiondto)
        {
          
            // Map DTO with Domain

            //var updateregionDomainModel = new Regions()
            //{
            //    Name = updateregiondto.Name,
            //    Code = updateregiondto.Code,
            //    RegionImageUrl = updateregiondto.RegionImageUrl
            //};
          
                var updateregionDomainModel = mapper.Map<Regions>(updateregiondto);

                updateregionDomainModel = await regionRepository.UpdateRegionsAsync(id, updateregionDomainModel);

                // Check if DTO exist or not
                if (updateregionDomainModel == null)
                {
                    return NotFound("No data found with this Id.");
                }

                // Map Domain to DTO

                //var updateregionDTOModel = new RegionsDto
                //{
                //    Id = updateregionDomainModel.Id,
                //    Code = updateregionDomainModel.Code,
                //    Name = updateregionDomainModel.Name,
                //    RegionImageUrl = updateregionDomainModel.RegionImageUrl

                //};

                var updateregionDTOModel = mapper.Map<RegionsDto>(updateregionDomainModel);

                return Ok(updateregionDTOModel);
            
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            var deleteregionDomainModel = await regionRepository.DeleteRegionAsync(id);
            if(deleteregionDomainModel == null)
            {
                return NotFound("No data found with this Id.");
            }

            // Map Domain to DTO
            //var regionDTO = new RegionsDto
            //{
            //    Id = deleteregionDomainModel.Id,
            //    Code = deleteregionDomainModel.Code,
            //    Name = deleteregionDomainModel.Name,
            //    RegionImageUrl = deleteregionDomainModel.RegionImageUrl

            //};

            var regionDTO = mapper.Map<RegionsDto>(deleteregionDomainModel);

            return Ok(regionDTO);    // return Ok($"{regionDTO.Id} data deleted successfully")
        }
    }
}
