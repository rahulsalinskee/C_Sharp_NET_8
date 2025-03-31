using Client.Management.API.DTOs.LoginDTO;
using Client.Management.API.DTOs.RegisterDTO;
using Client.Management.API.DTOs.ResponseDTOs;
using Client.Management.API.Repository.Services;
using Microsoft.AspNetCore.Identity;

namespace Client.Management.API.Repository.Implementations
{
    public class ClientRegisterServiceImplementation : IClientRegisterService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IClientTokenService _clientTokenService;

        public ClientRegisterServiceImplementation(UserManager<IdentityUser> userManager, IClientTokenService clientTokenService)
        {
            this._userManager = userManager;
            this._clientTokenService = clientTokenService;
        }

        public async Task<ResponseDto> RegisterClientAsync(RegisterRequestDto registerRequestDto)
        {
            if (registerRequestDto is not null)
            {
                IdentityUser identityUser = new()
                {
                    UserName = registerRequestDto.UserName,
                    Email = registerRequestDto.UserName
                };

                var identityUserResult = await this._userManager.CreateAsync(user: identityUser, password: registerRequestDto.Password);

                if (identityUserResult.Succeeded)
                {
                    if (registerRequestDto.Roles.Any())
                    {
                        identityUserResult = await this._userManager.AddToRolesAsync(user: identityUser, roles: registerRequestDto.Roles);

                        if (identityUserResult.Succeeded)
                        {
                            return new ResponseDto()
                            {
                                Result = identityUserResult,
                                IsSuccess = true,
                                DisplayMessage = "User registered successfully",
                            };
                        }
                    }
                }
            }
            return new ResponseDto()
            {
                Result = null,
                IsSuccess = false,
                DisplayMessage = "User registration failed",
            };
        }

        public async Task<ResponseDto> LoginClientAsync(LoginRequestDto loginRequestDto)
        {
            LoginResponseDto? loginResponseDto = null;

            if (loginRequestDto is not null)
            {
                var user = await this._userManager.FindByEmailAsync(email: loginRequestDto.UserName);

                if (user is not null)
                {
                    var isPasswordMatched = await this._userManager.CheckPasswordAsync(user: user, password: loginRequestDto.Password);

                    if (isPasswordMatched)
                    {
                        /* Create JWT */
                        var userDetailRoles = await this._userManager.GetRolesAsync(user: user);

                        if (userDetailRoles is not null)
                        {
                            var jwtToken = this._clientTokenService.GenerateToken(identityUser: user, roles: userDetailRoles);

                            loginResponseDto = new()
                            {
                                Token = jwtToken,
                            };
                        }

                        return new ResponseDto()
                        {
                            Result = loginResponseDto,
                            IsSuccess = true,
                            DisplayMessage = "User is validated successfully!",
                        };
                    }
                }
            }

            return new ResponseDto()
            {
                Result = loginResponseDto,
                IsSuccess = false,
                DisplayMessage = "User name or password is not matched!",
            };
        }
    }
}
