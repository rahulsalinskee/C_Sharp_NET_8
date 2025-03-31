using System.ComponentModel.DataAnnotations;

namespace Client.Management.API.DTOs.RegisterDTO
{
    public class RegisterRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string[] Roles { get; set; }
    }
}
