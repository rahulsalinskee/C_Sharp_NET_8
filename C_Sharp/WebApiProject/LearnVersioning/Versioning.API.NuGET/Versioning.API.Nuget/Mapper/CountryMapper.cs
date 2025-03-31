using Versioning.API.Nuget.DTOs;
using Versioning.API.Nuget.Models;

namespace Versioning.API.Nuget.Mapper
{
    public static class CountryMapper
    {
        /// <summary>
        /// Extension Mapper Method
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public static CountryDtoV1 FromCountryToCountryDtoV1(this Country country)
        {
            return new CountryDtoV1()
            {
                ID = country.ID,
                Name = country.Name,
            };
        }

        /// <summary>
        /// Extension Mapper Method
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public static CountryDtoV2 FromCountryToCountryDtoV2(this Country country)
        {
            return new CountryDtoV2()
            {
                ID = country.ID,
                CountryName = country.Name,
            };
        }
    }
}
