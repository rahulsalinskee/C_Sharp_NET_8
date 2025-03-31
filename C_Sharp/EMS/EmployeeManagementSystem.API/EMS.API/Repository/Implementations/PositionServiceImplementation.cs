using AutoMapper;
using EMS.API.DataContext;
using EMS.API.DTOs.PositionDTOs;
using EMS.API.DTOs.ResponseDTOs;
using EMS.API.Repository.Services;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Repository.Implementations
{
    public class PositionServiceImplementation : IPositionService
    {
        private readonly EMSDataBaseContext _emsDataBaseContext;
        private readonly IMapper _mapper;

        public PositionServiceImplementation(EMSDataBaseContext emsDataBaseContext, IMapper mapper)
        {
            this._emsDataBaseContext = emsDataBaseContext;
            this._mapper = mapper;
        }
        public Task<ResponseDto> AddPositionAsync(PositionCreateRequestDto positionCreateRequestDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> DeletePositionByIdAsync(int positionId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> GetPositionByIdAsync(int positionId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> GetPositionsAsync()
        {
            var a = this._emsDataBaseContext.Positions.AsNoTracking().ToListAsync();

            throw new NotImplementedException();
        }

        public Task<ResponseDto> UpdatePositionByIdAsync(int positionId, PositionUpdateRequestDto positionUpdateRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
