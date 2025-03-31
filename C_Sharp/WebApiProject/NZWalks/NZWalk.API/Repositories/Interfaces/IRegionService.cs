using Microsoft.AspNetCore.Mvc;
using NZWalk.API.Models.Domain;
using NZWalk.API.Models.DTO;

namespace NZWalk.API.Repositories.Interfaces
{
    public interface IRegionService
    {
        public Task<IEnumerable<RegionDto>> GetAllRegionsAsync();

        public Task<RegionDto?> GetRegionByIdAsync(Guid id);

        public Task<(RegionDto, Region)> CreateRegionAsync(AddRegionRequestDto addRegionRequestDto);

        public Task<RegionDto?> UpdateRegionById(Guid id, UpdateRegionRequestDto updateRegionRequestDto);

        public Task<RegionDto?> DeleteRegionAsync(Guid id);
    }
}
