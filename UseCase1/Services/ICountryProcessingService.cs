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

        /// <summary>
        /// Filters a collection of countries based on a population threshold. If the 'countryPopulationFilter' parameter is null, no filtering is applied.
        /// The <paramref name="countryPopulationFilter"/> represents population in millions. For example, providing a value of 10 filters the countries to those with a population less than 10 million.
        /// </summary>
        /// <param name="countries">A collection of <see cref="CountryDto"/> objects representing the countries to filter.</param>
        /// <param name="countryPopulationFilter">The population filter in millions. Can be <see langword="null"/>, in which case no filtering is applied.</param>
        /// <returns>A filtered collection of <see cref="CountryDto"/> objects where the population is less than the population filter multiplied by 1 million. If the <paramref name="countryPopulationFilter"/> is <see langword="null"/>, the original collection is returned.</returns>
        IQueryable<CountryDto> FilterByPopulation(IQueryable<CountryDto> countries, int? countryPopulationFilter);

        /// <summary>
        /// Sorts the collection of countries by the common name in either ascending or descending order based on the provided sort order parameter.
        /// </summary>
        /// <param name="countries">A collection of <see cref="CountryDto"/> objects representing the countries to sort.</param>
        /// <param name="countryNameSortOrder">The sort order parameter which can either be "ascend" or "descend". Any other value will throw an argument exception.</param>
        /// <returns>A collection of <see cref="CountryDto"/> objects sorted by the common name in the specified order.</returns>
        /// <exception cref="ArgumentException">Thrown when an incorrect value is provided for the countryNameSortOrder parameter.</exception>
        IQueryable<CountryDto> SortByCountryName(IQueryable<CountryDto> countries, string countryNameSortOrder);
    }
}
