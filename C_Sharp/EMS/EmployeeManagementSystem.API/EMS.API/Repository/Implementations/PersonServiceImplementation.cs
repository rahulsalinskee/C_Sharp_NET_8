using AutoMapper;
using EMS.API.DataContext;
using EMS.API.DTOs.PersonDTOs;
using EMS.API.DTOs.ResponseDTOs;
using EMS.API.Mapper.PersonUpdateMapper;
using EMS.API.Models;
using EMS.API.Repository.Services;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.Repository.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private readonly EMSDataBaseContext _emsDataBaseContext;
        private readonly IMapper _mapper;

        public PersonServiceImplementation(EMSDataBaseContext emsDataBaseContext, IMapper mapper)
        {
            this._emsDataBaseContext = emsDataBaseContext;
            this._mapper = mapper;
        }

        public async Task<ResponseDto> AddPersonAsync(PersonCreateRequestDto personCreateRequestDto)
        {
            if (personCreateRequestDto is not null)
            {
                var person = this._mapper.Map<Person>(source: personCreateRequestDto);

                await this._emsDataBaseContext.Persons.AddAsync(person);
                await this._emsDataBaseContext.SaveChangesAsync();

                var personDto = this._mapper.Map<PersonDto>(source: person);

                return new ResponseDto()
                {
                    Result = personDto,
                    Message = "Person added successfully",
                    IsSuccess = true,
                };
            }

            return new ResponseDto()
            {
                Result = null,
                Message = "Failed to add Person",
                IsSuccess = false,
            };
        }

        public async Task<ResponseDto> DeletePersonByIdAsync(int id)
        {
            var person = await this._emsDataBaseContext.Persons.FirstOrDefaultAsync(person => person.ID == id);

            if (person is not null)
            {
                var personDto = this._mapper.Map<PersonDto>(source: person);

                this._emsDataBaseContext.Persons.Remove(person);
                await this._emsDataBaseContext.SaveChangesAsync();

                return new ResponseDto()
                {
                    Result = personDto,
                    Message = "Person deleted successfully",
                    IsSuccess = true,
                };
            }

            return new ResponseDto()
            {
                Result = null,
                Message = "Person not found",
                IsSuccess = false,
            };
        }

        public async Task<ResponseDto> GetPersonByIdAsync(int id)
        {
            var person = await this._emsDataBaseContext.Persons.FirstOrDefaultAsync(person => person.ID == id);

            if (person is not null)
            {
                var personDto = this._mapper.Map<PersonDto>(source: person);
                return new ResponseDto()
                {
                    Result = personDto,
                    Message = "Person fetched successfully",
                    IsSuccess = true,
                };
            }

            return new ResponseDto()
            {
                Result = null,
                Message = "Person not found",
                IsSuccess = false,
            };
        }

        public async Task<ResponseDto> GetPersonsAsync()
        {
            var persons = await this._emsDataBaseContext.Persons.ToListAsync();

            var personsDto = this._mapper.Map<IEnumerable<PersonDto>>(source: persons);

            if (personsDto is not null)
            {
                return new ResponseDto()
                {
                    Result = personsDto,
                    Message = personsDto.Any() ? $"{personsDto.Count()} Persons fetched successfully" : "No Person Found!",
                    IsSuccess = true,
                };
            }

            return new ResponseDto()
            {
                Result = null,
                Message = "Failed to fetch Persons",
                IsSuccess = false,
            };
        }

        public async Task<ResponseDto> UpdatePersonByIdAsync(int id, DTOs.PersonDTOs.PersonUpdateRequestDto personUpdateRequestDto)
        {
            var person = this._emsDataBaseContext.Persons.FirstOrDefaultAsync(person => person.ID == id);

            if (person is not null)
            {
                var updatedPerson = personUpdateRequestDto.ToUpdatePersonModelFromPersonDtoExtension(id: id);

                this._emsDataBaseContext.Entry(person).State = EntityState.Detached;
                this._emsDataBaseContext.Attach(updatedPerson);
                this._emsDataBaseContext.Entry(updatedPerson).State = EntityState.Modified;

                await this._emsDataBaseContext.SaveChangesAsync();

                var updatedPersonDto = this._mapper.Map<PersonDto>(source: updatedPerson);

                return new ResponseDto()
                {
                    Result = updatedPersonDto,
                    Message = "Person updated successfully",
                    IsSuccess = true,
                };
            }

            return new ResponseDto()
            {
                Result = null,
                Message = "Person not found",
                IsSuccess = false,
            };
        }
    }
}
