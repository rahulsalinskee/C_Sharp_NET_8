using System.ComponentModel.DataAnnotations;

namespace EMS.API.Models
{
    public class Salary
    {
        [Key]
        public int SalaryID { get; set; }

        [Required]
        public int Amount { get; set; }

        public virtual ICollection<Person> Persons { get; set; }

        public Salary()
        {
            Persons = new HashSet<Person>();
        }
    }
}
