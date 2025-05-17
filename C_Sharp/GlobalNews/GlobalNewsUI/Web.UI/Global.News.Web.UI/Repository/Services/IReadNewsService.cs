using Global.News.Library.DTOs.ResponseDTOs;

namespace Global.News.Web.UI.Repository.Services
{
    public interface IReadNewsService
    {
        public Task<ResponseDto> GetGlobalNewsApiResponseAsync();
    }
}
