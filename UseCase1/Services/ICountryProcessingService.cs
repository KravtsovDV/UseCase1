using UseCase1.DTO;

namespace UseCase1.Services
{
    /// <summary>
    /// Represents a service for processing country information.
    /// </summary>
    public interface ICountryProcessingService
    {
        /// <summary>
        /// Filters a collection of countries based on a partial country name match. If the filter string is <see langword="null"/> or whitespace, no filtering is applied.
        /// </summary>
        /// <param name="countries">A collection of <see cref="CountryDto"/> objects representing the countries to filter.</param>
        /// <param name="countryNameFilter">The partial country name string to filter the countries collection on. Case insensitive. Can be <see langword="null"/>, in which case no filtering is applied.</param>
        /// <returns>A filtered collection of <see cref="CountryDto"/> objects where the country name contains the filter string. If the filter string is <see langword="null"/> or whitespace, the original collection is returned.</returns>
        IQueryable<CountryDto> FilterByCountryName(IQueryable<CountryDto> countries, string? countryNameFilter);
    }
}
