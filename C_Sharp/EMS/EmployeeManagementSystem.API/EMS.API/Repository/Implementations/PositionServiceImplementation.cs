using AutoMapper;
using EMS.API.DataContext;
using EMS.API.DTOs.PositionDTOs;
using EMS.API.DTOs.ResponseDTOs;
using EMS.API.Mapper.PositionUpdateMapper;
using EMS.API.Models;
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
        public async Task<ResponseDto> AddPositionAsync(PositionCreateRequestDto positionCreateRequestDto)
        {
            if (positionCreateRequestDto is not null)
            {
                var position = this._mapper.Map<Position>(source: positionCreateRequestDto);

                await this._emsDataBaseContext.Positions.AddAsync(position);
                await this._emsDataBaseContext.SaveChangesAsync();

                var positionDto = this._mapper.Map<PositionDto>(source: position);
                return new ResponseDto()
                {
                    Result = positionDto,
                    Message = "Position added successfully",
                    IsSuccess = true,
                };
            }

            return new ResponseDto()
            {
                Result = null,
                Message = "Failed to add Position",
                IsSuccess = false,
            };
        }

        public async Task<ResponseDto> DeletePositionByIdAsync(int positionId)
        {
            var position = await this._emsDataBaseContext.Positions.FirstOrDefaultAsync(predicate: position => position.PositionID == positionId);

            if (position is not null)
            {
                this._emsDataBaseContext.Remove(position);
                await this._emsDataBaseContext.SaveChangesAsync();

                var deletedPositionDto = this._mapper.Map<PositionDto>(source: position);

                return new ResponseDto()
                {
                    Result = deletedPositionDto,
                    Message = "Position deleted successfully",
                    IsSuccess = true,
                };
            }

            return new ResponseDto()
            {
                Result = null,
                Message = "Position not found",
                IsSuccess = false,
            };
        }

        public async Task<ResponseDto> GetPositionByIdAsync(int positionId)
        {
            var position = await this._emsDataBaseContext.Positions.FirstOrDefaultAsync(predicate: position => position.PositionID == positionId);

            if (position is not null)
            {
                var positionDto = this._mapper.Map<PositionDto>(source: position);

                return new ResponseDto()
                {
                    Result = positionDto,
                    Message = "Position fetched successfully",
                    IsSuccess = true,
                };
            }

            throw new NotImplementedException();
        }

        public async Task<ResponseDto> GetPositionsAsync()
        {
            var positions = await this._emsDataBaseContext.Positions.AsNoTracking().ToListAsync();

            if (positions is not null)
            {
                var positionDtos = this._mapper.Map<IEnumerable<PositionDto>>(source: positions);

                if (positionDtos.Any())
                {
                    return new ResponseDto()
                    {
                        Result = positionDtos,
                        Message = positionDtos.Count() > 1 ? $"{positionDtos.Count()} Positions fetched successfully" : "1 Position fetched successfully",
                        IsSuccess = true,
                    }; 
                }
            }

            return new ResponseDto()
            {
                Result = null,
                Message = "No Positions found",
                IsSuccess = false,
            };
        }

        public async Task<ResponseDto> UpdatePositionByIdAsync(int positionId, PositionUpdateRequestDto positionUpdateRequestDto)
        {
            var position = await this._emsDataBaseContext.Positions.FirstOrDefaultAsync(predicate: position => position.PositionID == positionId);

            if (position is not null)
            {
                var updatedPosition = positionUpdateRequestDto.ToUpdatePositionModelFromPositionDtoExtension(id: positionId);

                this._emsDataBaseContext.Entry(position).State = EntityState.Detached;
                this._emsDataBaseContext.Attach(updatedPosition);
                this._emsDataBaseContext.Entry(updatedPosition).State = EntityState.Modified;

                var updatedPositionDto = this._mapper.Map<PositionDto>(source: updatedPosition);

                await this._emsDataBaseContext.SaveChangesAsync();

                return new ResponseDto()
                {
                    Result = updatedPositionDto,
                    Message = "Position updated successfully",
                    IsSuccess = true,
                };
            }

            return new ResponseDto()
            {
                Result = null,
                Message = "Position not found",
                IsSuccess = false,
            };
        }
    }
}
