namespace EMS.API.DTOs.ErrorDTOs
{
    public class ErrorDto
    {
        public string ErrorId { get; set; } = string.Empty;

        public string ErrorDate { get; set; } = string.Empty;

        public string ErrorStatusCode { get; set; } = string.Empty;

        public string ErrorMessage { get; set; } = string.Empty;

        public string StackTrace { get; set; } = string.Empty;

        public string InnerException { get; set; } = string.Empty;
    }
}
