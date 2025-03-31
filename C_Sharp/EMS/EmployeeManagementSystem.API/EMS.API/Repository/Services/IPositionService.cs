using EMS.API.DTOs.PositionDTOs;
using EMS.API.DTOs.ResponseDTOs;

namespace EMS.API.Repository.Services
{
    public interface IPositionService
    {
        public Task<ResponseDto> GetPositionsAsync();

        public Task<ResponseDto> GetPositionByIdAsync(int positionId);

        public Task<ResponseDto> AddPositionAsync(PositionCreateRequestDto positionCreateRequestDto);

        public Task<ResponseDto> UpdatePositionByIdAsync(int positionId, PositionUpdateRequestDto positionUpdateRequestDto);

        public Task<ResponseDto> DeletePositionByIdAsync(int positionId);
    }
}
