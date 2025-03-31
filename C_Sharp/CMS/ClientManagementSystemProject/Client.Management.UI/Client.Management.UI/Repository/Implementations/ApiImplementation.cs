using Client.Management.UI.DTOs;
using Client.Management.UI.DTOs.ResponseDTOs;
using Client.Management.UI.Repository.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Client.Management.UI.Repository.Implementations
{
    internal class ApiImplementation : IApiService
    {
        private readonly HttpClient _httpClient;
        private const string BASE_URL = "https://localhost:7042/api/client";

        public ApiImplementation(HttpClient httpClient)
        {
            this._httpClient = httpClient;
            this._httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ResponseDto> CreateClientAsync(ClientDto clientDto)
        {
            string json = JsonConvert.SerializeObject(clientDto);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await this._httpClient.PostAsync(BASE_URL, content);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                return new ResponseDto()
                {
                    IsSuccess = true,
                    Message = "Client created successfully",
                    Result = JsonConvert.DeserializeObject<ClientDto>(jsonResponse),
                };
            }

            return new ResponseDto()
            {
                IsSuccess = false,
                Message = "Failed to create client",
                Result = null,
            };
        }

        public async Task<ResponseDto> DeleteClientByIdAsync(Guid id)
        {
            HttpResponseMessage response = await this._httpClient.DeleteAsync(BASE_URL + $"/{id}");

            if (response.IsSuccessStatusCode)
            {
                return new ResponseDto()
                {
                    IsSuccess = true,
                    Result = response,
                    Message = "Client deleted successfully",
                }; 
            }

            return new ResponseDto()
            {
                Result = null,
                IsSuccess = false,
                Message = "Failed to delete client",
            };
        }

        public async Task<ResponseDto> GetAllClientsAsync()
        {
            HttpResponseMessage response = await this._httpClient.GetAsync(BASE_URL);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return new ResponseDto()
                {
                    IsSuccess = true,
                    Message = "Clients fetched successfully",
                    Result = JsonConvert.DeserializeObject<IEnumerable<ClientDto>>(json),
                };
            }

            return new ResponseDto()
            {
                IsSuccess = false,
                Message = "Failed to fetch clients",
                Result = null,
            };
        }

        public async Task<ResponseDto> GetClientByIdAsync(Guid id)
        {
            HttpResponseMessage response = await this._httpClient.GetAsync(BASE_URL + $"/{id}");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return new ResponseDto()
                {
                    IsSuccess = true,
                    Message = "Client fetched successfully",
                    Result = JsonConvert.DeserializeObject<ClientDto>(json),
                };
            }
            return new ResponseDto()
            {
                IsSuccess = false,
                Message = "Failed to fetch client",
                Result = null,
            };
        }

        public async Task<ResponseDto> UpdateClientByIdAsync(Guid id, ClientDto clientDto)
        {
            var json = JsonConvert.SerializeObject(clientDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await this._httpClient.PutAsync(BASE_URL + $"/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                return new ResponseDto()
                {
                    IsSuccess = true,
                    Message = "Client updated successfully",
                    Result = JsonConvert.DeserializeObject<ClientDto>(responseJson),
                };
            }

            return new ResponseDto()
            {
                Result = null,
                IsSuccess = false,
                Message = "Failed to update client",
            };
        }
    }
}
