namespace NZWalk.API.Models.DTO
{
    public class ResponseDto
    {
        public object? Result { get; set; }

        public bool IsSuccess { get; set; } = default;

        public string DisplayMessage { get; set; } = string.Empty;
    }
}
