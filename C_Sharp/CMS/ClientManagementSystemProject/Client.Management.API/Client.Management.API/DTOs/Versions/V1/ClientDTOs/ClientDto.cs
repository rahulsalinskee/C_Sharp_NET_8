using System.ComponentModel.DataAnnotations;

namespace Client.Management.API.DTOs.Versions.V1.ClientDTOs
{
    public class ClientDto
    {
        [Required]
        public Guid ID { get; set; }

        [Required]
        [StringLength(maximumLength:50, MinimumLength = 1, ErrorMessage = "Client First name must be in between 1 and 50 characters.")]
        public string FirstName { get; set; } = string.Empty;

        public string? LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits long.")]
        public string Phone { get; set; } = string.Empty;

        [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "Address must be in between 5 and 100 characters.")]
        public string? Address { get; set; }
    }
}
