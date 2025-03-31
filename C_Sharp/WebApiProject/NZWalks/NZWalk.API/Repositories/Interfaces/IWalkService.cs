using NZWalk.API.Models.Domain;
using NZWalk.API.Models.DTO.WalkDto;

namespace NZWalk.API.Repositories.Interfaces
{
    public interface IWalkService
    {
        public Task<IEnumerable<WalkDto>> GetAllWalksAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 100);

        public Task<WalkDto?> GetWalkByIdAsync(Guid id);

        public Task<(WalkDto, Walk)> CreateWalkRequestAsync(AddWalkRequestDto addWalkRequestDto);

        public Task<WalkDto?> UpdateWalkRequestByIdAsync(Guid id, UpdateWalkRequestDto updateWalkRequestDto);

        public Task<WalkDto?> DeleteWalkRequestByIdAsync(Guid id);
    }
}
