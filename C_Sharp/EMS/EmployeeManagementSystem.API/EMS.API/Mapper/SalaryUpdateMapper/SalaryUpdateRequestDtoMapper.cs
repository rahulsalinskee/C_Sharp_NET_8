using EMS.API.DTOs.SalaryDTOs;
using EMS.API.Models;

namespace EMS.API.Mapper.SalaryUpdateMapper
{
    public static class SalaryUpdateRequestDtoMapper
    {
        public static Salary ToUpdateSalaryModelFromPositionDtoExtension(this SalaryUpdateRequestDto salaryUpdateRequestDto, int id)
        {
            return new Salary()
            {
                Amount = salaryUpdateRequestDto.Amount ?? 0,
            };
        }
    }
}
