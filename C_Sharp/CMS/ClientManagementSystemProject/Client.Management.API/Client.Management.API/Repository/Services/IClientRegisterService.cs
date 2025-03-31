using Client.Management.API.DTOs.LoginDTO;
using Client.Management.API.DTOs.RegisterDTO;
using Client.Management.API.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Identity.Data;

namespace Client.Management.API.Repository.Services
{
    public interface IClientRegisterService
    {
        public Task<ResponseDto> RegisterClientAsync(RegisterRequestDto registerDto);

        public Task<ResponseDto> LoginClientAsync(LoginRequestDto loginRequestDto);
    }
}
