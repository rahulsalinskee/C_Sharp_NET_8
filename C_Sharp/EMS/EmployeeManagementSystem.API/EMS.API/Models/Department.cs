using System.ComponentModel.DataAnnotations;

namespace EMS.API.Models
{
    public class Department
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Position> Positions { get; set; }

        public Department()
        {
            Positions = new HashSet<Position>();
        }
    }
}
