using EMS.API.DTOs.PersonDTOs;
using EMS.API.DTOs.ResponseDTOs;

namespace EMS.API.Repository.Services
{
    public interface IPersonService
    {
        public Task<ResponseDto> GetPersonsAsync();

        public Task<ResponseDto> GetPersonByIdAsync(int id);

        public Task<ResponseDto> AddPersonAsync(PersonCreateRequestDto personCreateRequestDto);

        public Task<ResponseDto> UpdatePersonByIdAsync(int id, PersonUpdateRequestDto personUpdateRequestDto);

        public Task<ResponseDto> DeletePersonByIdAsync(int id);
    }
}
