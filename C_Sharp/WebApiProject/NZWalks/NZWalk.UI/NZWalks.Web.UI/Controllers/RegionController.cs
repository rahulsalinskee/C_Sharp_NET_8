using Microsoft.AspNetCore.Mvc;
using NZWalks.Web.UI.DTOs;
using NZWalks.Web.UI.ViewModels;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

namespace NZWalks.Web.UI.Controllers
{
    public class RegionController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegionController(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<RegionDto>? response = new List<RegionDto>();
            try
            {
                var client = this._httpClientFactory.CreateClient();
                var httpResponseMessage = await client.GetAsync("https://localhost:7144/api/regions");
                httpResponseMessage.EnsureSuccessStatusCode();
                response = await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<RegionDto>>();
            }
            catch (Exception exception)
            {
                ViewBag.Response = "Exception: " + exception.Message;
            }
            return View(response);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRegionViewModel addRegionViewModel)
        {
            var client = this._httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://localhost:7144/api/regions"),
                Method = HttpMethod.Post,
                Content = new StringContent(JsonSerializer.Serialize(addRegionViewModel), Encoding.UTF8, "application/json")
            };


            var httpResponseMessage = await client.SendAsync(request: httpRequestMessage);
            //httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<RegionDto>();

            if (response is not null)
            {
                return RedirectToAction("Index", "Region");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = this._httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<RegionDto>($"https://localhost:7144/api/regions/{id.ToString()}");

            if (response is not null)
            {
                return View(response);
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RegionDto regionDto)
        {
            var client = this._httpClientFactory.CreateClient();

            HttpRequestMessage httpRequestMessage = new()
            {
                RequestUri = new Uri($"https://localhost:7144/api/regions/{regionDto.Id}"),
                Method = HttpMethod.Put,
                Content = new StringContent(JsonSerializer.Serialize(regionDto), Encoding.UTF8, "application/json")
            };

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);

            httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<RegionDto>();

            if (response  is not null)
            {
                return RedirectToAction("Index", "Region");
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RegionDto regionDto)
        {
            var client = this._httpClientFactory.CreateClient();
            var httpResponseMessage = await client.DeleteAsync($"https://localhost:7144/api/regions/{regionDto.Id}");
            httpResponseMessage.EnsureSuccessStatusCode();
            return RedirectToAction("Index", "Region");
        }
    }
}
