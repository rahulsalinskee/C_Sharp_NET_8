using EMS.API.Models;

namespace EMS.API.Mapper.DepartmentUpdateMapper
{
    public static class DepartmentUpdateRequestDtoMapper
    {
        public static Department ToUpdateDepartmentModelFromDepartmentDtoExtension(this DTOs.DepartmentDTOs.DepartmentUpdateRequestDto departmentUpdateRequestDto, int id)
        {
            return new Department()
            {
                Name = departmentUpdateRequestDto.Name ?? string.Empty,
            };
        }
    }
}
