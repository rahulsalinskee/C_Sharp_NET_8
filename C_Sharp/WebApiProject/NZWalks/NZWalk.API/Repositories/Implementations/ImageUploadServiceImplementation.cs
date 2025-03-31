using AutoMapper;
using NZWalk.API.Data;
using NZWalk.API.Models.Domain;
using NZWalk.API.Models.DTO.ImageDTOs;
using NZWalk.API.Repositories.Interfaces;

namespace NZWalk.API.Repositories.Implementations
{
    public class ImageUploadServiceImplementation : IImageUploadService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly NZWalksDbContext _nzWalksDbContext;
        private readonly IMapper _mapper;

        public ImageUploadServiceImplementation(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, NZWalksDbContext nzWalksDbContext, IMapper mapper)
        {
            this._webHostEnvironment = webHostEnvironment;
            this._httpContextAccessor = httpContextAccessor;
            this._nzWalksDbContext = nzWalksDbContext;
            this._mapper = mapper;
        }

        public async Task<(ImageDto?, string)> UploadImageAsync(ImageUploadRequestDto imageUploadRequestDto)
        {
            string errorMessage = ValidationForFileUploadRequest(imageUploadRequestDto);
            ImageDto? imageDto = default;

            if (string.IsNullOrEmpty(errorMessage))
            {
                /* Convert Image DTO to image Model */
                var imageDomainModel = new Image
                {
                    File = imageUploadRequestDto.File,
                    FileExtension = Path.GetExtension(path: imageUploadRequestDto.File.FileName),
                    FileSizeInBytes = imageUploadRequestDto.File.Length,
                    FileName = imageUploadRequestDto.FileName,
                };

                /* Local path variable so that it points to this images folder in our project */
                var localFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", $"{imageDomainModel.FileName}{imageDomainModel.FileExtension}");

                /* Upload Image To Local Path */
                using var fileStream = new FileStream(localFilePath, FileMode.Create);
                await imageDomainModel.File.CopyToAsync(fileStream);

                /* To serve an image the URL should be like this: https://localhost:123/images/image.jpg | This file path is going to upload to the table */
                var urlFilepath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://" +
                    $"{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}/Images/{imageDomainModel.FileName}{imageDomainModel.FileExtension}";

                imageDomainModel.FilePath = urlFilepath;

                /* Add the images to images table */
                await this._nzWalksDbContext.Images.AddAsync(imageDomainModel);

                /* Save the changes */
                await this._nzWalksDbContext.SaveChangesAsync();

                /* Ensure the entity is properly refreshed after save */
                await this._nzWalksDbContext.Entry(imageDomainModel).ReloadAsync();

                /* Convert Image Model to Image DTO */
                imageDto = this._mapper.Map<ImageDto>(source: imageDomainModel);
            }

            /* Return Image DTO && error message */
            return (imageDto, errorMessage);
        }

        private static string ValidationForFileUploadRequest(ImageUploadRequestDto imageUploadRequestDto)
        {
            var allowedExtension = new string[] { ".jpg", ".jpeg", ".png", ".gif" };
            var errorMessage = string.Empty;

            /* Throw error if the file extension is different from the allowed file extension */
            if (!allowedExtension.Contains(Path.GetExtension(path: imageUploadRequestDto.File.FileName), StringComparer.OrdinalIgnoreCase))
            {
                errorMessage = "Invalid file extension. Allowed extensions are .jpg, .jpeg, .png, .gif";
            }

            /* Throw error if the file size exceeds from 10MB */
            if (imageUploadRequestDto.File.Length > 10485760)
            {
                errorMessage = "File Size is more than 10 MB";
            }

            return errorMessage;
        }
    }
}
