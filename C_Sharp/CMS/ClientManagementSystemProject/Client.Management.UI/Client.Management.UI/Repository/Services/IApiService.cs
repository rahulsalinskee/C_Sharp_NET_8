using Client.Management.UI.DTOs;
using Client.Management.UI.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Management.UI.Repository.Services
{
    public interface IApiService
    {
        public Task<ResponseDto> GetAllClientsAsync();

        public Task<ResponseDto> GetClientByIdAsync(Guid id);

        public Task<ResponseDto> CreateClientAsync(ClientDto clientDto);

        public Task<ResponseDto> UpdateClientByIdAsync(Guid id, ClientDto clientDto);

        public Task<ResponseDto> DeleteClientByIdAsync(Guid id);
    }
}
