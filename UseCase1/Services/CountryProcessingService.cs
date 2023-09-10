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
    }
}
