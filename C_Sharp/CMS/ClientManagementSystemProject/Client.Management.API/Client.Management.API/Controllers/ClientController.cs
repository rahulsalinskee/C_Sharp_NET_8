using Client.Management.API.CustomValidations;
using Client.Management.API.DTOs.Versions.V1.ClientDTOs;
using Client.Management.API.Repository.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Client.Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private const string CLIENT_ID = "{clientId:guid}";
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            this._clientService = clientService;
        }

        [HttpGet]
        [ModelValidation]
        [Authorize(Roles = "NonAdministrator")]
        public async Task<IActionResult> GetClientsAsync()
        {
            var response = await this._clientService.GetClientsAsync();

            if (response.Result is not null && response.IsSuccess)
            {
                return Ok(response.Result);
            }
            else
            {
                return BadRequest(response.DisplayMessage);
            }
        }

        [HttpGet]
        [ActionName("GetClientById")]
        [Route(CLIENT_ID)]
        [ModelValidation]
        [Authorize(Roles = "NonAdministrator")]
        public async Task<IActionResult> GetClientByIdAsync([FromRoute] Guid clientId)
        {
            var response = await this._clientService.GetClientByIdAsync(id: clientId);
            if (response.Result is not null && response.IsSuccess)
            {
                return Ok(response.Result);
            }
            else
            {
                return BadRequest(response.DisplayMessage);
            }
        }

        [HttpPost]
        [ModelValidation]
        [ActionName("AddClient")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddClientRequestAsync([FromBody] AddClientRequestDto addClientRequestDto)
        {
            var response = await this._clientService.AddClientAsync(addClientRequestDto: addClientRequestDto);

            if (response.Result is not null && response.IsSuccess)
            {
                return Ok(response.Result);
            }
            else
            {
                return BadRequest(response.DisplayMessage);
            }
        }

        [HttpPut]
        [ModelValidation]
        [Route(CLIENT_ID)]
        [ActionName("UpdateClientById")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateClientByIdAsync([FromRoute] Guid clientId, [FromBody] UpdateClientRequestDto updateClientRequestDto)
        {
            var response = await this._clientService.UpdateClientByIdAsync(id: clientId, updateClientRequestDto: updateClientRequestDto);

            if (response.Result is not null && response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.DisplayMessage);
            }
        }

        [HttpDelete]
        [ModelValidation]
        [ActionName("DeleteClient")]
        [Route(CLIENT_ID)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteClientByIdAsync([FromRoute] Guid clientId)
        {
            var response = await this._clientService.DeleteClientByIdAsync(id: clientId);

            if (response.Result is not null && response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.DisplayMessage);
            }
        }
    }
}
