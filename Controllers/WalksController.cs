using AutoMapper;
using INDWalks.CustomActionValidations;
using INDWalks.Data;
using INDWalks.Models.Domain;
using INDWalks.Models.DTOs;
using INDWalks.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace INDWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalksRepository walksRepository;
        private readonly IMapper mapper;

        public WalksController(IWalksRepository walksRepository, IMapper mapper)
        {

            this.walksRepository = walksRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateWalks([FromBody] WalksRequestDTO walksrequestdto)
        {

                // Map Dto to Domain
                var WalkDomain = mapper.Map<Walks>(walksrequestdto);

                WalkDomain = await walksRepository.CreateAsyc(WalkDomain);

                // Map Domain to Dto
                var WalkDto = mapper.Map<WalksDto>(WalkDomain);

                //return Ok(WalkDto);
                return CreatedAtAction(nameof(GetWalksById), new { id = WalkDto.Id }, WalkDto);
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterquery, [FromQuery] string? sortby, [FromQuery] bool? isAscending, [FromQuery] int pagenumber, [FromQuery] int pagesize)
        {
            var WalkDomain = await walksRepository.GetAllAsync(filterOn,filterquery, sortby, isAscending ?? true, pagenumber, pagesize);

            var WalkDto = mapper.Map<List<WalksDto>>(WalkDomain);
            return Ok(WalkDto);
        }


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetWalksById([FromRoute] Guid id)
        {
            var WalkDomain = await walksRepository.GetbyIdAsync(id);
            if(WalkDomain == null)
            {
                return NotFound("No data exist with this Id.");
            }
            var WalkDto = mapper.Map<WalksDto>(WalkDomain);
            return Ok(WalkDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateWalks([FromRoute] Guid id, [FromBody] UpdateWalkRequestDTO updatewalkRequestdto)
        {

                // Map DTO to Domain

                var WalkDomain = mapper.Map<Walks>(updatewalkRequestdto);

                WalkDomain = await walksRepository.UpdateWalkAsync(id, WalkDomain);

                if (WalkDomain == null)
                {
                    return NotFound("No data exist with this Id.");
                }

                // Map Domain to DTO

                var Walkdto = mapper.Map<WalksDto>(WalkDomain);

                return Ok(Walkdto);
            
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteWalks([FromRoute] Guid id)
        {
            var WalkDomain = await walksRepository.DeleteWalkAsync(id);
            if (WalkDomain == null)
            {
                return NotFound("No data exist with this Id.");
            }
            var WalkDto = mapper.Map<WalksDto>(WalkDomain);
            return Ok(WalkDto);
        }




    };
}
