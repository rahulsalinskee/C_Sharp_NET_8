using EMS.API.DTOs.PersonDTOs;
using EMS.API.Repository.Services;
using EMS.API.ServerSideValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            this._personService = personService;
        }

        [HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        [ValidateModel]
        public async Task<IActionResult> GetAllPersons()
        {
            var persons = await this._personService.GetPersonsAsync();

            if (persons is not null && persons.IsSuccess)
            {
                return Ok(persons);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [ValidateModel]
        [Route("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPersonById([FromRoute] int id)
        {
            var person = await this._personService.GetPersonByIdAsync(id: id);

            if (person is not null && person.IsSuccess)
            {
                return Ok(person);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateModel]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddPerson([FromBody] PersonCreateRequestDto personCreateRequestDto)
        {
            var response = await this._personService.AddPersonAsync(personCreateRequestDto: personCreateRequestDto);
            if (response is not null && response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPut]
        [ValidateModel]
        [Route("{personId:int}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdatePersonById([FromRoute] int personId, [FromBody] PersonUpdateRequestDto personUpdateRequestDto)
        {
            var response = await this._personService.UpdatePersonByIdAsync(id: personId, personUpdateRequestDto: personUpdateRequestDto);

            if (response is not null && response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpDelete]
        [ValidateModel]
        [Route("{id:int}")]
        public async Task<IActionResult> DeletePersonById([FromRoute] int id)
        {
            var response = await this._personService.DeletePersonByIdAsync(id);

            if (response is not null && response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
