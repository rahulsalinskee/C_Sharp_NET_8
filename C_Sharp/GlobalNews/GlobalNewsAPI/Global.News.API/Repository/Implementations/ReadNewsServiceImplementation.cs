using Global.News.API.DTOs.ResponseDTOs;
using Global.News.API.DTOs.RootDTOs;
using Global.News.API.Repository.Services;
using Global.News.API.Utilities;
using Newtonsoft.Json;

namespace Global.News.API.Repository.Implementations
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

        public async Task<ResponseDto> ReadNewsAsync()
        {
            RootDto rootDto = new();
            HttpResponseMessage httpResponseMessage = await this._httpClient.GetAsync(StaticDetails.GlobalNewsApiUrl);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var jsonStringResponse = await httpResponseMessage.Content.ReadAsStringAsync();

                rootDto = JsonConvert.DeserializeObject<RootDto>(jsonStringResponse);

                this._responseDto.Result = rootDto;
                this._responseDto.Message = "News Loaded Successfully!";
                this._responseDto.IsSuccess = true;
            }
            else
            {
                this._responseDto.Result = null;
                this._responseDto.Message = "Error In Loading News!";
                this._responseDto.IsSuccess = false;
                return this._responseDto;
            }
            return this._responseDto;
        }
    }
}
