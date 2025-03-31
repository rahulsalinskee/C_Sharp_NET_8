using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalk.API.CustomActionFilter;
using NZWalk.API.Data;
using NZWalk.API.Models.Domain;
using NZWalk.API.Models.DTO;
using NZWalk.API.Repositories.Interfaces;
using System.Net;
using System.Text.Json;

namespace NZWalk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionsController(IRegionService regionService)
        {
            this._regionService = regionService;
        }

        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            /* Throwing an intensional exception */
            //throw new Exception("This is a custom exception");

            var regionDto = await this._regionService.GetAllRegionsAsync();

            if (regionDto is not null && regionDto.Any())
            {
                /* Return DTO to the client */
                return Ok(regionDto);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("{id:guid}")]
        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetRegionByIdAsync([FromRoute] Guid id)
        {
            var regionDto = await this._regionService.GetRegionByIdAsync(id: id);

            if (regionDto is null)
            {
                return BadRequest();
            }
            else
            {
                /* Return DTO to the client */
                return Ok(regionDto);
            }
        }

        [HttpPost]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateRegionAsync([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            var regionResult = await this._regionService.CreateRegionAsync(addRegionRequestDto);

            var regionDto = regionResult.Item1;
            var regionModel = regionResult.Item2;

            if (regionDto is not null)
            {
                /* Return Response */
                return CreatedAtAction
                    (
                        actionName: nameof(GetRegionByIdAsync),
                        controllerName: nameof(RegionsController),
                        routeValues: new { id = regionModel.Id },
                        value: regionDto
                    );
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            var regionDto = await this._regionService.UpdateRegionById(id, updateRegionRequestDto);

            if (regionDto is not null)
            {
                /* Return DTO */
                return Ok(regionDto);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("{id:guid}")]
        [HttpDelete]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteRegionAsync([FromRoute] Guid id)
        {
            var regionDto = await this._regionService.DeleteRegionAsync(id);

            if (regionDto is not null)
            {
                /* Return deleted region back */
                return Ok(regionDto);

                /* Return Response without DTO - This is also fine with deletion if not to return deleted object */
                // return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
