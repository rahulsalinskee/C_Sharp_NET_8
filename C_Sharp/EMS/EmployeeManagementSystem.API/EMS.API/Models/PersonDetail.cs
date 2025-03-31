using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.API.Models
{
    public class PersonDetail
    {
        public int ID { get; set; }

        public string PersonCity { get; set; } = string.Empty;

        public DateTime Birthday { get; set; }

        [ForeignKey("Person")]
        public int PersonID { get; set; }

        public Person Person { get; set; }
    }
}
