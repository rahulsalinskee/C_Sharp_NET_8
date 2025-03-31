using AutoMapper;
using Client.Management.API.Data;
using Client.Management.API.DTOs.ResponseDTOs;
using Client.Management.API.DTOs.Versions.V1.ClientDTOs;
using Client.Management.API.Mappers;
using Client.Management.API.Models;
using Client.Management.API.Repository.Services;
using Microsoft.EntityFrameworkCore;

namespace Client.Management.API.Repository.Implementations
{
    public class ClientServiceImplementation : IClientService
    {
        private readonly IMapper _mapper;
        private readonly ResponseDto _responseDto;
        private readonly ClientDataContext _clientDataContext;

        public ClientServiceImplementation(ClientDataContext clientDataContext, IMapper mapper, ResponseDto responseDto)
        {
            this._mapper = mapper;
            this._responseDto = responseDto;
            this._clientDataContext = clientDataContext;
        }

        public async Task<ResponseDto> AddClientAsync(AddClientRequestDto clientRequestDto)
        {
            Models.Client? client = default;
            ClientDto? clientDto = default;

            if (clientRequestDto is not null)
            {
                client = this._mapper.Map<Models.Client>(source: clientRequestDto);
                await this._clientDataContext.Clients.AddAsync(client);
                await this._clientDataContext.SaveChangesAsync();

                clientDto = this._mapper.Map<ClientDto>(source: client);
                this._responseDto.IsSuccess = true;
                this._responseDto.Result = clientDto;
                this._responseDto.DisplayMessage = "Client Added Successfully";
            }
            else
            {
                this._responseDto.Result = null;
                this._responseDto.IsSuccess = false;
                this._responseDto.DisplayMessage = "Client Not Added";
            }

            return this._responseDto;
        }

        public async Task<ResponseDto> DeleteClientByIdAsync(Guid id)
        {
            var client = await this._clientDataContext.Clients.FindAsync(id);

            if (client is not null)
            {
                this._clientDataContext.Clients.Remove(client);
                await this._clientDataContext.SaveChangesAsync();
                this._responseDto.Result = this._mapper.Map<ClientDto>(source: client);
                this._responseDto.IsSuccess = true;
                this._responseDto.DisplayMessage = "Client Deleted Successfully";
            }
            else
            {
                this._responseDto.Result = null;
                this._responseDto.IsSuccess = false;
                this._responseDto.DisplayMessage = "Client Not Deleted";
            }

            return this._responseDto;
        }

        public async Task<ResponseDto> GetClientByIdAsync(Guid id)
        {
            var client = await this._clientDataContext.Clients.FirstOrDefaultAsync(client => client.ID == id);

            if (client is not null)
            {
                this._responseDto.Result = this._mapper.Map<ClientDto>(source: client);
                this._responseDto.IsSuccess = true;
                this._responseDto.DisplayMessage = "Client Found";
            }
            else
            {
                this._responseDto.Result = null;
                this._responseDto.IsSuccess = false;
                this._responseDto.DisplayMessage = "Client Not Found";
            }

            return this._responseDto;
        }

        public async Task<ResponseDto> GetClientsAsync()
        {
            var clients = await this._clientDataContext.Clients.AsNoTracking().ToListAsync();

            if (clients.Any())
            {
                var clientsDto = this._mapper.Map<IEnumerable<ClientDto>>(source: clients);
                this._responseDto.Result = clientsDto;
                this._responseDto.DisplayMessage = clients.Count > 1 ? $"{clients.Count} Clients Found" : $"{clients.Count} Client Found";
                this._responseDto.IsSuccess = true;
            }
            else
            {
                this._responseDto.IsSuccess = false;
                this._responseDto.Result = null;
                this._responseDto.DisplayMessage = "No Clients Found";
            }

            return _responseDto;
        }

        public async Task<ResponseDto> UpdateClientByIdAsync(Guid id, UpdateClientRequestDto updateClientRequestDto)
        {
            var client = await this._clientDataContext.Clients.FindAsync(id);

            if (client is not null)
            {
                var updatedClient = updateClientRequestDto.FromUpdateClientRequestDtoToClientV1(id: id);

                this._clientDataContext.Entry(client).State = EntityState.Detached;
                this._clientDataContext.Attach(updatedClient);
                this._clientDataContext.Entry(updatedClient).State = EntityState.Modified;

                await this._clientDataContext.SaveChangesAsync();

                this._responseDto.Result = this._mapper.Map<ClientDto>(source: updatedClient);
                this._responseDto.IsSuccess = true;
                this._responseDto.DisplayMessage = "Client Updated Successfully";
            }
            else
            {
                this._responseDto.Result = null;
                this._responseDto.IsSuccess = false;
                this._responseDto.DisplayMessage = "Client Not Updated";
            }

            return this._responseDto;
        }
    }
}
