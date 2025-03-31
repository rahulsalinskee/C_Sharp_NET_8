using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalk.API.CustomActionFilter;
using NZWalk.API.Models.DTO.WalkDto;
using NZWalk.API.Repositories.Interfaces;

namespace NZWalk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {
        private readonly IWalkService _walkService;

        public WalkController(IWalkService walkService)
        {
            this._walkService = walkService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalksAsync([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy, [FromQuery] bool? isAscending, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 100)
        {
            var walks = await this._walkService.GetAllWalksAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);

            if (walks == null)
            {
                return NotFound();
            }
            return Ok(walks);
        }

        [Route("{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetWalkByIdAsync([FromRoute] Guid id)
        {
            var walkModel = await this._walkService.GetWalkByIdAsync(id: id);

            if (walkModel == null)
            {
                return NotFound();
            }
            return Ok(walkModel);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateWalkAsync([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            var result = await this._walkService.CreateWalkRequestAsync(addWalkRequestDto: addWalkRequestDto);

            var walkDto = result.Item1;

            var walkModel = result.Item2;

            /* Return Response */
            return CreatedAtAction(actionName: nameof(GetWalkByIdAsync), routeValues: new { id = walkModel.Id }, value: walkDto);
        }

        [Route("{id:guid}")]
        [HttpPut]
        [ValidateModel]
        public async Task<IActionResult> UpdateWalkByIdAsync([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            var walkDto = await this._walkService.UpdateWalkRequestByIdAsync(id: id, updateWalkRequestDto: updateWalkRequestDto);

            if (walkDto is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(walkDto);
            }
        }

        [Route("{id:guid}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteWalkByIdAsync([FromRoute] Guid id)
        {
            var walkDto = await this._walkService.DeleteWalkRequestByIdAsync(id: id);

            if (walkDto is not null)
            {
                return Ok(walkDto);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
