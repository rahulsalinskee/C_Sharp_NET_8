using Global.News.API.Repository.Services;
using Global.News.API.ServerSideValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Global.News.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IReadNewsService _readNewsService;

        public NewsController(IReadNewsService readNewsService)
        {
            this._readNewsService = readNewsService;
        }

        [HttpGet]
        [ValidateModel]
        public async Task<IActionResult> GetNewsToReadAsync()
        {
            var response = await this._readNewsService.ReadNewsAsync();

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
