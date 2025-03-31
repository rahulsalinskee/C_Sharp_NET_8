namespace Client.Management.API.DTOs.ResponseDTOs
{
    public class ResponseDto
    {
        public object? Result { get; set; }

        public string DisplayMessage { get; set; } = string.Empty;

        public bool IsSuccess { get; set; } = default;
    }
}
