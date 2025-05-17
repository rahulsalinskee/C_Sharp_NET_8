using Global.News.Library.DTOs.ResponseDTOs;
using Global.News.Web.UI.Repository.Services;
using Global.News.Web.UI.Utilities;

namespace Global.News.Web.UI.Repository.Implementations
{
    public class ReadNewsServiceImplementation : IReadNewsService
    {
        private readonly HttpClient _httpClient;
        private readonly ResponseDto _responseDto;

        public ReadNewsServiceImplementation(HttpClient httpClient, ResponseDto responseDto)
        {
            this._httpClient = httpClient;
            this._responseDto = responseDto;
        }

        public async Task<ResponseDto> GetGlobalNewsApiResponseAsync()
        {
            var responseMessage = await this._httpClient.GetAsync(requestUri: StaticDetails.GlobalNewsApi);

            if (responseMessage.IsSuccessStatusCode)
            {

            }
            return this._responseDto;
        }
    }
}
