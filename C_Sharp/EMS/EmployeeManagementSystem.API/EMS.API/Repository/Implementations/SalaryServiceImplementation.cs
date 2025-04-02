using AutoMapper;
using EMS.API.DataContext;
using EMS.API.DTOs.ResponseDTOs;
using EMS.API.DTOs.SalaryDTOs;
using EMS.API.Mapper.SalaryUpdateMapper;
using EMS.API.Models;
using EMS.API.Repository.Services;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Repository.Implementations
{
    public class SalaryServiceImplementation : ISalaryService
    {
        private readonly EMSDataBaseContext _emsDataBaseContext;
        private readonly IMapper _mapper;

        public SalaryServiceImplementation(EMSDataBaseContext emsDataBaseContext, IMapper mapper)
        {
            this._emsDataBaseContext = emsDataBaseContext;
            this._mapper = mapper;
        }

        public async Task<ResponseDto> CreateSalaryAsync(SalaryCreateRequestDto salaryCreateRequestDto)
        {
            if (salaryCreateRequestDto is not null)
            {
                var salaryCreateRequest = this._mapper.Map<Salary>(source: salaryCreateRequestDto);
                await this._emsDataBaseContext.AddAsync(entity: salaryCreateRequest);
                await this._emsDataBaseContext.SaveChangesAsync();

                var salaryDto = this._mapper.Map<SalaryDto>(source: salaryCreateRequest);

                return new ResponseDto()
                {
                    Result = salaryDto,
                    Message = "Salary created successfully",
                    IsSuccess = true,
                };
            }

            return new ResponseDto()
            {
                Result = null,
                Message = "Salary not created",
                IsSuccess = false,
            };
        }

        public async Task<ResponseDto> DeleteSalaryByIdAsync(int id)
        {
            var salary = await this._emsDataBaseContext.Salaries.FirstOrDefaultAsync(predicate: salary => salary.SalaryID == id);

            if (salary is not null)
            {
                this._emsDataBaseContext.Remove(entity: salary);
                await this._emsDataBaseContext.SaveChangesAsync();

                var deletedSalaryDto = this._mapper.Map<SalaryDto>(source: salary);

                return new ResponseDto()
                {
                    Result = deletedSalaryDto,
                    Message = "Salary deleted successfully",
                    IsSuccess = true,
                };
            }

            return new ResponseDto()
            {
                Result = null,
                Message = "Salary not found",
                IsSuccess = false,
            };
        }

        public async Task<ResponseDto> GetSalariesAsync()
        {
            var salaries = await this._emsDataBaseContext.Salaries.ToListAsync();

            if (salaries is not null)
            {
                var salariesDto = this._mapper.Map<IEnumerable<SalaryDto>>(source: salaries);

                if (salariesDto.Any())
                {
                    return new ResponseDto()
                    {
                        Result = salariesDto,
                        Message = salariesDto.Count() > 1 ? $"{salariesDto.Count()} Salaries fetched successfully" : "1 Salary fetched successfully",
                        IsSuccess = true,
                    };
                }
            }

            return new ResponseDto()
            {
                Result = null,
                Message = "No Salary Found!",
                IsSuccess = false,
            };
        }

        public async Task<ResponseDto> GetSalaryByIdAsync(int id)
        {
            var salary = await this._emsDataBaseContext.Salaries.FirstOrDefaultAsync(predicate: salary => salary.SalaryID == id);

            if (salary is not null)
            {
                var salaryDto = this._mapper.Map<SalaryDto>(source: salary);

                return new ResponseDto()
                {
                    Result = salaryDto,
                    Message = "Salary fetched successfully",
                    IsSuccess = true,
                };
            }

            return new ResponseDto()
            {
                Result = null,
                Message = "Salary not found",
                IsSuccess = false,
            };
        }

        public async Task<ResponseDto> UpdateSalaryByIdAsync(int id, SalaryUpdateRequestDto salaryUpdateRequestDto)
        {
            var salary = await this._emsDataBaseContext.Salaries.FirstOrDefaultAsync(predicate: salary => salary.SalaryID == id);

            if (salary is not null)
            {
                var updatedSalary = salaryUpdateRequestDto.ToUpdateSalaryModelFromPositionDtoExtension(id: id);

                this._emsDataBaseContext.Entry(entity: salary).State = EntityState.Detached;
                this._emsDataBaseContext.Attach(entity: updatedSalary);
                this._emsDataBaseContext.Entry(entity: updatedSalary).State = EntityState.Modified;

                await this._emsDataBaseContext.SaveChangesAsync();

                var updatedSalaryDto = this._mapper.Map<SalaryDto>(source: updatedSalary);

                return new ResponseDto()
                {
                    Result = updatedSalaryDto,
                    Message = "Salary updated successfully",
                    IsSuccess = true,
                };
            }

            return new ResponseDto()
            {
                Result = null,
                Message = "Salary not found",
                IsSuccess = false,
            };
        }
    }
}
