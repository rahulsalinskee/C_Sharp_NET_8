using Client.Management.API.DTOs.Versions.V1.ClientDTOs;

namespace Client.Management.API.Mappers
{
    public static class ClientMapper
    {
        public static Models.Client FromUpdateClientRequestDtoToClientV1(this UpdateClientRequestDto updateClientRequestDto, Guid id)
        {
            return new Models.Client()
            {
                ID = id,
                FirstName = updateClientRequestDto.FirstName,
                LastName = updateClientRequestDto.LastName,
                Address = updateClientRequestDto.Address,
                Email = updateClientRequestDto.Email,
                Phone = updateClientRequestDto.Phone,
            };
        }
    }
}
