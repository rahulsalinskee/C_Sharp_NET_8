using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalk.API.Models.Domain;
using NZWalk.API.Models.DTO.ImageDTOs;
using NZWalk.API.Repositories.Interfaces;

namespace NZWalk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageUploadService _imageUploadService;

        public ImagesController(IImageUploadService imageUploadService)
        {
            this._imageUploadService = imageUploadService;
        }

        [HttpPost, ActionName("upload")]
        [Route("upload")]
        public async Task<IActionResult> UploadImageAsync([FromForm] ImageUploadRequestDto imageUploadRequestDto)
        {
            var result = await this._imageUploadService.UploadImageAsync(imageUploadRequestDto:  imageUploadRequestDto);

            var imageDto = result.Item1;

            var errorMessage = result.Item2;

            if (string.IsNullOrEmpty(errorMessage) && imageDto is not null && ModelState.IsValid)
            {
                /* Convert Image DTO to Image Model */
                Image imageModel = new()
                {
                    File = imageDto.File,
                    FileExtension = Path.GetExtension(imageDto.File.FileName),
                    FileName = imageDto.FileName,
                    FileSizeInBytes = imageDto.File.Length,
                    FileDescription = imageDto.FileDescription,
                };

                /* Return OK Response */
                return Ok(imageModel);
            }
            else
            {
                ModelState.AddModelError(key: "file", errorMessage: errorMessage);

                /* Return Bad Request */
                return BadRequest(ModelState);
            }
        }
    }
}
