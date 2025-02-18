using INDWalks.Data;
using INDWalks.Models.Domain;
using INDWalks.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INDWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly INDWalksDbContext dbContext;

        public RegionsController(INDWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //Get data from DB - via Domain Models

            var regionsDomain = dbContext.Regions.ToList();


            //Map Domain Models to DTOs
            var regionDTO = new List<RegionsDto>();
            foreach(var region in regionsDomain)
            {
                regionDTO.Add(new RegionsDto()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl
                });
            }

            // return DTOs 

            return Ok(regionDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetRegionById([FromRoute]Guid id)
        {
            var regionDomain = dbContext.Regions.Find(id);
            if(regionDomain == null)
            {
                return NotFound("No data found with this Id.");
            }

            //Map Domain Models to DTO

            var regionDTO = new RegionsDto()
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl

            }; 
            return Ok(regionDTO);
        }

        [HttpPost]

        public IActionResult CreateRegion([FromBody]AddRegionRequestDto addregionreqdto)
        {

            // Map DTO to Domain
            var regionDomain = new Regions
            {
                Name = addregionreqdto.Name,
                Code = addregionreqdto.Code,
                RegionImageUrl = addregionreqdto.RegionImageUrl
            };

            // Use Domain Models to Create entry in Db.
            dbContext.Regions.Add(regionDomain);
            dbContext.SaveChanges();

            // Map Domain Model back to DTO

            var regionDTO = new RegionsDto
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl

            };

            return CreatedAtAction(nameof(GetRegionById), new {id = regionDTO.Id},regionDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]

        public IActionResult UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateregiondto)
        {
            // Check if DTO exist or not
            var updateregionDomainModel = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if(updateregionDomainModel == null)
            {
                return NotFound();
            }

            // Map DTO to Domain
            updateregionDomainModel.Code = updateregiondto.Code;
            updateregionDomainModel.Name = updateregiondto.Name;
            updateregionDomainModel.RegionImageUrl = updateregiondto.RegionImageUrl;

            dbContext.SaveChanges();

            // Map Domain to DTO

            var updateregionDTOModel = new RegionsDto
            {
                Id = updateregionDomainModel.Id,
                Code = updateregionDomainModel.Code,
                Name = updateregionDomainModel.Name,
                RegionImageUrl = updateregionDomainModel.RegionImageUrl

            };

            return Ok(updateregionDTOModel);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        
        public IActionResult DeleteRegion([FromRoute] Guid id)
        {
            var deleteregionDomainModel = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if(deleteregionDomainModel == null)
            {
                return NotFound();
            }

            dbContext.Regions.Remove(deleteregionDomainModel);
            dbContext.SaveChanges();

            // Map Domain to DTO
            var regionDTO = new RegionsDto
            {
                Id = deleteregionDomainModel.Id,
                Code = deleteregionDomainModel.Code,
                Name = deleteregionDomainModel.Name,
                RegionImageUrl = deleteregionDomainModel.RegionImageUrl

            };
            
            return Ok(regionDTO);    // return Ok($"{regionDTO.Id} data deleted successfully")
        }
    }
}
