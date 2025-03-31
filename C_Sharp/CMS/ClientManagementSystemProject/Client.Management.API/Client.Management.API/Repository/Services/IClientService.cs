using Client.Management.API.DTOs.ResponseDTOs;
using Client.Management.API.DTOs.Versions.V1.ClientDTOs;

namespace Client.Management.API.Repository.Services
{
    public interface IClientService
    {
        public Task<ResponseDto> GetClientsAsync();

        public Task<ResponseDto> GetClientByIdAsync(Guid id);

        public Task<ResponseDto> AddClientAsync(AddClientRequestDto addClientRequestDto);

        public Task<ResponseDto> UpdateClientByIdAsync(Guid id, UpdateClientRequestDto updateClientRequestDto);

        public Task<ResponseDto> DeleteClientByIdAsync(Guid id);
    }
}
