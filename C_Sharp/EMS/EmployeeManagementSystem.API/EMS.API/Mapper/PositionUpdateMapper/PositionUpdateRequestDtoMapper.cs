using EMS.API.DTOs.PositionDTOs;
using EMS.API.Models;

namespace EMS.API.Mapper.PositionUpdateMapper
{
    public static class PositionUpdateRequestDtoMapper
    {
        public static Position ToUpdatePositionModelFromPositionDtoExtension(this PositionUpdateRequestDto positionUpdateRequestDto, int id)
        {
            return new Position()
            {
                Name = positionUpdateRequestDto.Name ?? string.Empty,
                DepartmentId = positionUpdateRequestDto.DepartmentId ?? id,
            };
        }
    }
}
