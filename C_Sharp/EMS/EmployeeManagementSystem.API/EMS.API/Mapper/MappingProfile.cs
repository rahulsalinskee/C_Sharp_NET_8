using AutoMapper;
using EMS.API.DTOs.DepartmentDTOs;
using EMS.API.DTOs.PersonDetailDTOs;
using EMS.API.DTOs.PersonDTOs;
using EMS.API.DTOs.PositionDTOs;
using EMS.API.DTOs.SalaryDTOs;
using EMS.API.Models;

namespace EMS.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Person mappings
            CreateMap<Person, PersonDto>()
                .ForMember(destination => destination.PersonDetail, option => option.MapFrom(src => src.PersonDetail));

            CreateMap<PersonCreateRequestDto, Person>()
                .ForMember(destination => destination.PersonDetail, option => option.MapFrom(src => src.PersonDetail));

            CreateMap<PersonUpdateRequestDto, Person>()
                .ForMember(destination => destination.PersonDetail, option => option.MapFrom(source => source.PersonDetail))
                .ForMember(destination => destination.FirstName, option => option.Condition(source => source.FirstName is not null))
                .ForMember(destination => destination.LastName, option => option.Condition(source => source.LastName is not null))
                .ForMember(destination => destination.Age, option => option.Condition(source => source.Age != null))
                .ForMember(destination => destination.Email, option => option.Condition(source => source.Email is not null))
                .ForMember(destination => destination.Address, option => option.Condition(source => source.Address is not null))
                .ForMember(destination => destination.PositionID, option => option.Condition(source => source.PositionID != null))
                .ForMember(destination => destination.SalaryID, option => option.Condition(source => source.SalaryID != null));

            // PersonDetail mappings
            CreateMap<PersonDetail, PersonDetailDto>();

            CreateMap<PersonDetailCreateRequestDto, PersonDetail>();

            CreateMap<PersonDetailUpdateRequestDto, PersonDetail>()
                .ForMember(destination => destination.PersonCity, option => option.Condition(source => source.PersonCity is not null))
                .ForMember(destination => destination.Birthday, option => option.Condition(source => source.Birthday is not null));

            // Position mappings
            CreateMap<Position, PositionDto>();
            CreateMap<PositionCreateRequestDto, Position>();
            CreateMap<PositionUpdateRequestDto, Position>()
               .ForMember(destination => destination.Name, option => option.Condition(source => source.Name is not null))
               .ForMember(destination => destination.DepartmentId, option => option.Condition(src => src.DepartmentId != null));

            // Salary mappings
            CreateMap<Salary, SalaryDto>();
            CreateMap<SalaryCreateRequestDto, Salary>();
            CreateMap<SalaryUpdateRequestDto, Salary>()
                .ForMember(destination => destination.Amount, option => option.Condition(source => source.Amount is not null));

            // Department mappings
            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentCreateRequestDto, Department>();
            CreateMap<DepartmentUpdateRequestDto, Department>()
                .ForMember(destination => destination.Name, option => option.Condition(sources => sources.Name is not null));

        }
    }
}
