using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NZWalk.API.Data;
using NZWalk.API.Models.Domain;
using NZWalk.API.Models.DTO;
using NZWalk.API.Repositories.Interfaces;

namespace NZWalk.API.Repositories.Implementations
{
    public class RegionServiceImplementation : IRegionService
    {
        private readonly IMapper _mapper;
        private readonly NZWalksDbContext _nzWalksDbContext;

        public RegionServiceImplementation(IMapper mapper, NZWalksDbContext nzWalksDbContext)
        {
            this._mapper = mapper;
            this._nzWalksDbContext = nzWalksDbContext;
        }

        public async Task<(RegionDto, Region)> CreateRegionAsync(AddRegionRequestDto addRegionRequestDto)
        {
            /* Map/Convert DTO to model */
            var regionModel = this._mapper.Map<Region>(source: addRegionRequestDto);

            /* Use domain model to create object */
            await _nzWalksDbContext.Regions.AddAsync(regionModel);
            await _nzWalksDbContext.SaveChangesAsync();

            /* Map or convert model back to DTO */
            var regionDto = this._mapper.Map<RegionDto>(source: regionModel);

            /* Return DTO */
            return (regionDto, regionModel);
        }

        public async Task<RegionDto?> DeleteRegionAsync(Guid id)
        {
            /* Get the data (model) by using ID */
            var regionModel = await _nzWalksDbContext.Regions.FirstOrDefaultAsync(region => region.Id == id);

            if (regionModel is not null)
            {
                /* Delete the data (model) */
                _nzWalksDbContext.Regions.Remove(regionModel);

                /* Save the changes */
                await _nzWalksDbContext.SaveChangesAsync();

                /* Map or convert model to DTO */
                var regionDto = this._mapper.Map<RegionDto>(source: regionModel);

                /* Return DTO */
                return regionDto;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<RegionDto>> GetAllRegionsAsync()
        {
            /* Get data from database - Domain */
            var regionsModel = await this._nzWalksDbContext.Regions.ToListAsync();

            /* Map domain models to DTO */
            var regionDto = this._mapper.Map<IEnumerable<RegionDto>>(source: regionsModel);

            /* Return DTO */
            return regionDto;
        }

        public async Task<RegionDto?> GetRegionByIdAsync(Guid id)
        {
            /* Get Region domain model from database */

            /* 1st Way to find data using an ID */
            // var result = this._nzWalksDbContext.Regions.Find(id);

            /* 2nd Way to find data using an ID */
            var regionModel = await this._nzWalksDbContext.Regions.FirstOrDefaultAsync(region => region.Id == id);

            if (regionModel is not null)
            {
                /* Map/Convert region model to region DTO */
                var regionDto = this._mapper.Map<RegionDto>(source: regionModel);

                /* Return Region DTO */
                return regionDto; 
            }
            else
            {
                return null;
            }
        }

        public async Task<RegionDto?> UpdateRegionById(Guid id, UpdateRegionRequestDto updateRegionRequestDto)
        {
            var regionModel = await _nzWalksDbContext.Regions.FindAsync(id);

            if (regionModel is not null)
            {
                /* Update the value */
                regionModel.Code = updateRegionRequestDto.Code;
                regionModel.Name = updateRegionRequestDto.Name;
                regionModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

                /* Save the changes */
                await _nzWalksDbContext.SaveChangesAsync();

                /* Map or convert model to DTO */
                var regionDto = this._mapper.Map<RegionDto>(source: regionModel);

                    /* Return DTO */
                return regionDto; 
            }
            else
            {
                return null;
            }
        }
    }
}
