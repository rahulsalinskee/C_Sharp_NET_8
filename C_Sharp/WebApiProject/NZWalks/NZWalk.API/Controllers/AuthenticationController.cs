using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalk.API.Models.DTO.LoginDTOs;
using NZWalk.API.Models.DTO.RegisterDTOs;
using NZWalk.API.Repositories.Interfaces;

namespace NZWalk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _identityUserManager;
        private readonly ITokenService _tokenService;

        public AuthenticationController(UserManager<IdentityUser> identityUserManager, ITokenService tokenService)
        {
            this._identityUserManager = identityUserManager;
            this._tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequestDto registerRequestDto)
        {
            /* Creating an instance of Identity User (Coming from Asp.Net Core Identity Framework Core) and 
            * initializing UserName and Email properties with the user input coming from register request DTO 
            */
            IdentityUser identityUser = new()
            {
                UserName = registerRequestDto.UserName,
                Email = registerRequestDto.UserName,
            };

            /* Create User with help of Identity User (Coming from Asp.Net Core Identity Framework Core) instance */
            var identityUserResult = await this._identityUserManager.CreateAsync(user: identityUser, password: registerRequestDto.Password);

            /* Checking if user is created successfully */
            if (identityUserResult.Succeeded)
            {
                if (registerRequestDto is not null && registerRequestDto.Roles.Any())
                {
                    /* Create Role for user with help of Add Roles to Identity User */
                    identityUserResult = await _identityUserManager.AddToRolesAsync(user: identityUser, roles: registerRequestDto.Roles);

                    /* Check if role is added successfully */
                    if (identityUserResult.Succeeded)
                    {
                        /* Return OK response */
                        return Ok("User is registered! Please login!");
                    }
                }
            }

            return BadRequest("Something went wrong!");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDto loginRequestDto)
        {
            /* To check if the login request DTO is not NULL */
            if (loginRequestDto is not null)
            {
                /* Find user based on Email ID */
                var userDetail = await this._identityUserManager.FindByEmailAsync(email: loginRequestDto.UserName);

                /* Check - If user is not NULL */
                if (userDetail is not null)
                {
                    /* Check if existing password in database matches with the password provided by user */
                    var isPasswordMatched = await this._identityUserManager.CheckPasswordAsync(user: userDetail, password: loginRequestDto.Password);

                    if (isPasswordMatched)
                    {
                        /* Get the roles for the current user */
                        var currentUserRole = await this._identityUserManager.GetRolesAsync(user: userDetail);

                        /* To check if the current user role is not null */
                        if (currentUserRole is not null)
                        {
                            /* Create A JWT Token On Successful Login */
                            var jwtToken = this._tokenService.CreateJwtToken(identityUser: userDetail, roles: currentUserRole);

                            LoginResponseDto loginResponseDto = new()
                            {
                                JwtToken = jwtToken,
                            };

                            /* Return OK response when user validation is succeeded */
                            return Ok(loginResponseDto);
                        }
                    }
                }
            }
            /* Return Bad Request when user is not validated successfully */
            return BadRequest("User name or password is incorrect!");
        }
    }
}
