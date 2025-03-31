using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Versioning.API.Nuget.Database;
using Versioning.API.Nuget.DTOs;
using Versioning.API.Nuget.Mapper;

namespace Versioning.API.Nuget.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class CountryController : ControllerBase
    {
        [HttpGet]
        [ActionName("Countries")]
        [MapToApiVersion("1.0")]
        public IActionResult GetAllCountriesV1()
        {
            var countries = CountriesData.GetCountries();

            IList<CountryDtoV1> countriesDto = new List<CountryDtoV1>();
            CountryDtoV1 countryDto = new();

            foreach (var country in countries)
            {
                countryDto = country.FromCountryToCountryDtoV1();
                countriesDto.Add(countryDto);
            }

            return Ok(countriesDto);
        }

        [HttpGet]
        [ActionName("Countries")]
        [MapToApiVersion("2.0")]
        public IActionResult GetAllCountriesV2()
        {
            var countries = CountriesData.GetCountries();

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
