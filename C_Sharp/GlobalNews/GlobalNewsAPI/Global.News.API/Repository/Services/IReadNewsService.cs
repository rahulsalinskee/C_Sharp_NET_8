using Global.News.API.DTOs.ResponseDTOs;

namespace Global.News.API.Repository.Services
{
    public interface IReadNewsService
    {
        public Task<ResponseDto> ReadNewsAsync();
    }
}
