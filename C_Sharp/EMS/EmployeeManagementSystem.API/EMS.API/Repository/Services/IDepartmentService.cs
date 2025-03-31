using EMS.API.DTOs.DepartmentDTOs;
using EMS.API.DTOs.ResponseDTOs;

namespace EMS.API.Repository.Services
{
    public interface IDepartmentService
    {
        public Task<ResponseDto> GetAllDepartmentsAsync();

        public Task<ResponseDto> GetDepartmentByIdAsync(int id);

        public Task<ResponseDto> AddDepartmentAsync(DepartmentCreateRequestDto departmentCreateRequestDto);

        public Task<ResponseDto> UpdateDepartmentByIdAsync(int id, DepartmentUpdateRequestDto departmentUpdateRequestDto);

        public Task<ResponseDto> DeleteDepartmentByIdAsync(int id);
    }
}
