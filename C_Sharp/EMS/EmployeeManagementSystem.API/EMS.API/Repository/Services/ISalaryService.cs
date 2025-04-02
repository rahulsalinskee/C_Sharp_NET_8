using EMS.API.DTOs.ResponseDTOs;
using EMS.API.DTOs.SalaryDTOs;

namespace EMS.API.Repository.Services
{
    public interface ISalaryService
    {
        public Task<ResponseDto> GetSalariesAsync();

        public Task<ResponseDto> GetSalaryByIdAsync(int id);

        public Task<ResponseDto> CreateSalaryAsync(SalaryCreateRequestDto salaryCreateRequestDto);

        public Task<ResponseDto> UpdateSalaryByIdAsync(int id, SalaryUpdateRequestDto salaryUpdateRequestDto);

        public Task<ResponseDto> DeleteSalaryByIdAsync(int id);
    }
}
