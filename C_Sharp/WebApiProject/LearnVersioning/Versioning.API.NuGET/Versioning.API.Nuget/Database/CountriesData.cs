using Versioning.API.Nuget.Models;

namespace Versioning.API.Nuget.Database
{
    public static class CountriesData
    {
        public static IEnumerable<Country> GetCountries()
        {
            return new List<Country>()
    {
        new Country()
        {
            ID = 1,
            Name = "United States of America",
        },
        new Country()
        {
            ID = 2,
            Name = "United Kingdom"
        },
        new Country()
        {
            ID = 3,
            Name = "India"
        },
        new Country()
        {
            ID = 4,
            Name = "China"
        },
        new Country()
        {
            ID = 5,
            Name = "Brazil"
        },
        new Country()
        {
            ID = 6,
            Name= "South Africa"
        },
        new Country()
        {
            ID = 7,
            Name = "Australia"
        },
        new Country()
        {
            ID = 8,
            Name = "Canada"
        },
        new Country()
        {
            ID = 9,
            Name = "Chile"
        },
        new Country()
        {
            ID = 10,
            Name = "Bhutan"
        }
    };
        }
    }
}
