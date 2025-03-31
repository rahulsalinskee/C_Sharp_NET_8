using Client.Management.API.DTOs.LoginDTO;
using Client.Management.API.DTOs.RegisterDTO;
using Client.Management.API.Repository.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Client.Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientAuthenticationController : ControllerBase
    {
        private readonly IClientRegisterService _clientRegisterService;

        public ClientAuthenticationController(IClientRegisterService clientRegisterService)
        {
            this._clientRegisterService = clientRegisterService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterClientAsync([FromBody] RegisterRequestDto registerRequestDto)
        {
            var registerRequestResponseResult = await this._clientRegisterService.RegisterClientAsync(registerRequestDto);

            if (registerRequestResponseResult.IsSuccess && registerRequestResponseResult.Result is not null)
            {
                return Ok(registerRequestResponseResult.DisplayMessage);
            }
            else
            {
                return BadRequest(registerRequestResponseResult.DisplayMessage);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginClientAsync([FromBody] LoginRequestDto loginRequestDto)
        {
            var loginRequestResponseResult = await this._clientRegisterService.LoginClientAsync(loginRequestDto);

            if (loginRequestResponseResult.IsSuccess && loginRequestResponseResult.Result is not null)
            {
                return Ok(loginRequestResponseResult.Result);
            }
            else
            {
                return BadRequest(loginRequestResponseResult.DisplayMessage);
            }
        }
    }
}
