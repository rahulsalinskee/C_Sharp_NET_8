using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.API.Versioning.API.DTOs;
using Web.API.Versioning.API.Mapper;

namespace Web.API.Versioning.API.Versions.V1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        [HttpGet]
        [ActionName("Countries")]
        public IActionResult GetAllCountries()
        {
            var countries = CountriesData.CountriesData.GetCountries();

            IList<CountryDtoV1> countriesDto = new List<CountryDtoV1>();
            CountryDtoV1 countryDto = new();

            foreach (var country in countries)
            {
                countryDto = country.FromCountryToCountryDtoV1();
                countriesDto.Add(countryDto);
            }

            return Ok(countriesDto);
        }
    }
}
