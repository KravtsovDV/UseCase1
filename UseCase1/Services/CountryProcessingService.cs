using UseCase1.DTO;

namespace UseCase1.Services
{
    public class CountryProcessingService : ICountryProcessingService
    {
        public IQueryable<CountryDto> FilterByCountryName(IQueryable<CountryDto> countries, string? countryNameFilter)
        {
            if (string.IsNullOrWhiteSpace(countryNameFilter))
            {
                return countries;
            }

            return countries.Where(c => c.Name != null &&
                                        c.Name.Common != null &&
                                        c.Name.Common.Contains(countryNameFilter, StringComparison.OrdinalIgnoreCase));
        }

        public IQueryable<CountryDto> FilterByPopulation(IQueryable<CountryDto> countries, int? countryPopulationFilter)
        {
            if (!countryPopulationFilter.HasValue)
            {
                return countries;
            }

            int populationInMillions = countryPopulationFilter.Value * 1000000;
            return countries.Where(c => c.Population.HasValue && c.Population.Value < populationInMillions);
        }

        public IQueryable<CountryDto> SortByCountryName(IQueryable<CountryDto> countries, string countryNameSortOrder)
        {
            switch (countryNameSortOrder.ToLowerInvariant())
            {
                case "ascend":
                    return countries.OrderBy(c => c.Name == null ? string.Empty : c.Name.Common);

                case "descend":
                    return countries.OrderByDescending(c => c.Name == null ? string.Empty : c.Name.Common);

                default:
                    throw new ArgumentException($"The {nameof(countryNameSortOrder)} value is incorrect. It must be 'ascend' or 'descend'.");
            }
        }
    }
}
