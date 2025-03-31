using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.API.Models
{
    public class Position
    {
        [Key]
        public int PositionID { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public virtual ICollection<Person> Persons { get; set; }

        public Position()
        {
            Persons = new HashSet<Person>();
        }
    }
}
