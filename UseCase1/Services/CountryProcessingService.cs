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
    }
}
