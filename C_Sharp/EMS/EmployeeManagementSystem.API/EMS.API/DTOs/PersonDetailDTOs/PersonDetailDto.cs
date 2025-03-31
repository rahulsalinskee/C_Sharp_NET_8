namespace EMS.API.DTOs.PersonDetailDTOs
{
    public class PersonDetailDto
    {
        public int ID { get; set; }

        public string PersonCity { get; set; } = string.Empty;

        public DateTime Birthday { get; set; }

        public int PersonID { get; set; }
    }
}
