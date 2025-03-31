namespace EMS.API.DTOs.ResponseDTOs
{
    public class ResponseDto
    {
        public string Message { get; set; } = string.Empty;

        public bool IsSuccess { get; set; }

        public object? Result { get; set; }
    }
}
