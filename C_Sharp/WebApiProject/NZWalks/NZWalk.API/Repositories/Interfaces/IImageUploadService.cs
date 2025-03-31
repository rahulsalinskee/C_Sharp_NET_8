using NZWalk.API.Models.DTO.ImageDTOs;

namespace NZWalk.API.Repositories.Interfaces
{
    public interface IImageUploadService
    {
        public Task<(ImageDto, string)> UploadImageAsync(ImageUploadRequestDto imageUploadRequestDto);
    }
}
