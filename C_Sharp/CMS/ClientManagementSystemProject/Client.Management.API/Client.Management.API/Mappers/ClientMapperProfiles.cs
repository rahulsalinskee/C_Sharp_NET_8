using AutoMapper;
using Client.Management.API.DTOs.Versions.V1.ClientDTOs;

namespace Client.Management.API.Mappers
{
    public class ClientMapperProfiles : Profile
    {
        public ClientMapperProfiles()
        {
            CreateMap<Models.Client, ClientDto>().ReverseMap();
            CreateMap<AddClientRequestDto, Models.Client>().ReverseMap();
            CreateMap<UpdateClientRequestDto, Models.Client>().ReverseMap();
        }
    }
}
