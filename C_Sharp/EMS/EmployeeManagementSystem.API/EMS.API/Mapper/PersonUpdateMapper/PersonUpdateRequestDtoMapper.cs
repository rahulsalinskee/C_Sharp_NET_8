using EMS.API.DTOs.PersonDTOs;
using EMS.API.Models;

namespace EMS.API.Mapper.PersonUpdateMapper
{
    public static class PersonUpdateRequestDtoMapper
    {
        public static Person ToUpdatePersonModelFromPersonDtoExtension(this DTOs.PersonDTOs.PersonUpdateRequestDto personUpdateRequestDto, int id)
        {
            return new Person()
            {
                FirstName = personUpdateRequestDto.FirstName ?? string.Empty,
                LastName = personUpdateRequestDto.LastName ?? string.Empty,
                Age = personUpdateRequestDto.Age,
                Email = personUpdateRequestDto.Email,
                Address = personUpdateRequestDto.Address,
                PositionID = personUpdateRequestDto.PositionID,
                SalaryID = personUpdateRequestDto.SalaryID,
            };
        }
    }
}
