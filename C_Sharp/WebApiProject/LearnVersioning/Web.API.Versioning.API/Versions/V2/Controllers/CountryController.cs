using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.API.Versioning.API.DTOs;
using Web.API.Versioning.API.Mapper;

namespace Web.API.Versioning.API.Versions.V2.Controllers
{
    [Route("api/v2/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        [HttpGet]
        [ActionName("Countries")]
        public IActionResult GetAllCountries()
        {
            var countries = CountriesData.CountriesData.GetCountries();

            IList<CountryDtoV2> countriesDto = new List<CountryDtoV2>();
            CountryDtoV2 countryDto = new();

            foreach (var country in countries)
            {
                countryDto = country.FromCountryToCountryDtoV2();
                countriesDto.Add(countryDto);
            }

            return Ok(countriesDto);
        }
    }
}
