using AutoMapper;
using EMS.API.DataContext;
using EMS.API.DTOs.DepartmentDTOs;
using EMS.API.DTOs.ResponseDTOs;
using EMS.API.Mapper.DepartmentUpdateMapper;
using EMS.API.Models;
using EMS.API.Repository.Services;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Repository.Implementations
{
    public class DepartmentServiceImplementation : IDepartmentService
    {
        private readonly EMSDataBaseContext _emsDataBaseContext;
        private readonly IMapper _mapper;

        public DepartmentServiceImplementation(EMSDataBaseContext emsDataBaseContext, IMapper mapper)
        {
            this._emsDataBaseContext = emsDataBaseContext;
            this._mapper = mapper;
        }

        public async Task<ResponseDto> AddDepartmentAsync(DepartmentCreateRequestDto departmentCreateRequestDto)
        {
            if (departmentCreateRequestDto is not null)
            {
                var department = this._mapper.Map<Department>(source: departmentCreateRequestDto);
                
                await this._emsDataBaseContext.Departments.AddAsync(department);
                await this._emsDataBaseContext.SaveChangesAsync();

                var departmentDto = this._mapper.Map<DepartmentDto>(source: department);

                return new ResponseDto()
                {
                    Result = departmentDto,
                    Message = "Department added successfully",
                    IsSuccess = true,
                };
            }

            return new ResponseDto()
            {
                Result = null,
                Message = "Failed to add Department",
                IsSuccess = false,
            };
        }

        public async Task<ResponseDto> DeleteDepartmentByIdAsync(int id)
        {
            var department = await this._emsDataBaseContext.Departments.FirstOrDefaultAsync(predicate: department => department.ID == id);

            if (department is not null)
            {
                this._emsDataBaseContext.Remove(department);
                await this._emsDataBaseContext.SaveChangesAsync();

                var departmentDto = this._mapper.Map<DepartmentDto>(source: department);

                return new ResponseDto()
                {
                    Result = departmentDto,
                    Message = "Department deleted successfully",
                    IsSuccess = true,
                };
            }

            return new ResponseDto()
            {
                Result = null,
                Message = $"No Department found with ID: {id}",
                IsSuccess = false,
            };
        }

        public async Task<ResponseDto> GetAllDepartmentsAsync()
        {
            var departments = await this._emsDataBaseContext.Departments.AsNoTracking().ToListAsync();

            if (departments is not null)
            {
                var departmentsDto = this._mapper.Map<IEnumerable<DepartmentDto>>(source: departments);

                return new ResponseDto()
                {
                    Result = departmentsDto,
                    Message = departmentsDto.Count() > 1 ? $"{departmentsDto.Count()} Departments fetched successfully" : $"{departmentsDto.Count()} Department fetched successfully",
                    IsSuccess = true,
                };
            }

            return new ResponseDto()
            {
                Result = null,
                Message = "No Department found",
                IsSuccess = false,
            };
        }

        public async Task<ResponseDto> GetDepartmentByIdAsync(int id)
        {
            var department = await this._emsDataBaseContext.Departments.AsNoTracking().FirstOrDefaultAsync(predicate: department => department.ID == id);

            if (department is not null)
            {
                var departmentDto = this._mapper.Map<DepartmentDto>(source: department);

                return new ResponseDto()
                {
                    Result = departmentDto,
                    Message = "Department fetched successfully",
                    IsSuccess = true,
                };
            }

            return new ResponseDto()
            {
                Result = null,
                Message = $"No Department found with ID: {id}",
                IsSuccess = false,
            };
        }

        public async Task<ResponseDto> UpdateDepartmentByIdAsync(int id, DepartmentUpdateRequestDto departmentUpdateRequestDto)
        {
            var department = await this._emsDataBaseContext.Departments.FirstOrDefaultAsync(predicate: department => department.ID == id);

            if (department is not null)
            {
                var updateDepartment = departmentUpdateRequestDto.ToUpdateDepartmentModelFromDepartmentDtoExtension(id: id);

                this._emsDataBaseContext.Entry(department).State = EntityState.Detached;
                this._emsDataBaseContext.Attach(updateDepartment);
                this._emsDataBaseContext.Entry(updateDepartment).State = EntityState.Modified;

                await this._emsDataBaseContext.SaveChangesAsync();

                var departmentDto = this._mapper.Map<DepartmentDto>(source: updateDepartment);

                return new ResponseDto()
                {
                    Result = departmentDto,
                    Message = "Department updated successfully",
                    IsSuccess = true,
                };
            }

            return new ResponseDto()
            {
                Result = null,
                Message = $"No Department found with ID: {id}",
                IsSuccess = false,
            };
        }
    }
}
