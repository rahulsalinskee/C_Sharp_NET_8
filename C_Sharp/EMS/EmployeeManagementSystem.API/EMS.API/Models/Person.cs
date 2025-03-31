using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.API.Models
{
    public class Person
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public int Age { get; set; }

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public string? Address { get; set; }

        [ForeignKey("Position")]
        public int PositionID { get; set; }

        public Position Position { get; set; }

        [ForeignKey("Salary")]
        public int SalaryID { get; set; }

        public Salary Salary { get; set; }

        public virtual PersonDetail PersonDetail { get; set; }
    }
}
