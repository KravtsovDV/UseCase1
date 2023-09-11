using UseCase1.DTO;
using UseCase1.Services;

namespace UseCase1.Tests
{
    public class CountryProcessingServiceTests
    {
        private readonly ICountryProcessingService _service;

        public CountryProcessingServiceTests()
        {
            _service = new CountryProcessingService();
        }

        [Fact]
        public void FilterByCountryName_ShouldReturnAll_WhenFilterIsNull()
        {
            // Arrange
            var countries = GetTestCountries();
            string? countryNameFilter = null;

            // Act
            var result = _service.FilterByCountryName(countries, countryNameFilter);

            // Assert
            Assert.Equal(countries, result);
        }

        [Theory]
        [InlineData("in", new[] { "India", "Small Country" })]
        [InlineData("IN", new[] { "India", "Small Country" })]
        [InlineData("Country", new[] { "Small Country" })]
        public void FilterByCountryName_ShouldFilterCorrectly(string filter, string[] expectedResults)
        {
            // Arrange
            var countries = GetTestCountries();

            // Act
            var result = _service.FilterByCountryName(countries, filter);

            // Assert
            Assert.Equal(expectedResults, result.Select(r => r.Name == null ? null : r.Name.Common));
        }

        [Fact]
        public void FilterByPopulation_ShouldReturnAll_WhenFilterIsNull()
        {
            // Arrange
            var countries = GetTestCountries();
            int? populationFilter = null;

            // Act
            var result = _service.FilterByPopulation(countries, populationFilter);

            // Assert
            Assert.Equal(countries, result);
        }

        [Fact]
        public void FilterByPopulation_ShouldFilterCorrectly()
        {
            // Arrange
            var countries = GetTestCountries();
            int? populationFilter = 1000;

            // Act
            var result = _service.FilterByPopulation(countries, populationFilter);

            // Assert
            Assert.Equal(new[] { "Small Country", "Mid Country" }, result.Select(r => r.Name == null ? null : r.Name.Common));
        }

        [Theory]
        [InlineData("ascend", new[] { "India", "Mid Country", "Small Country", "USA" })]
        [InlineData("descend", new[] { "USA", "Small Country", "Mid Country", "India" })]
        public void SortByCountryName_ShouldSortCorrectly(string sortOrder, string[] expectedResults)
        {
            // Arrange
            var countries = GetTestCountries();

            // Act
            var result = _service.SortByCountryName(countries, sortOrder);

            // Assert
            Assert.Equal(expectedResults, result.Select(r => r.Name == null ? null : r.Name.Common));
        }

        [Fact]
        public void SortByCountryName_ShouldThrowException_ForInvalidSortOrder()
        {
            // Arrange
            var countries = GetTestCountries();
            string sortOrder = "invalid";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _service.SortByCountryName(countries, sortOrder));
        }

        [Theory]
        [InlineData(null, 4)]
        [InlineData(2, 2)]
        [InlineData(10, 4)] // More than available records
        public void LimitRecords_ShouldLimitCorrectly(int? recordLimit, int expectedCount)
        {
            // Arrange
            var countries = GetTestCountries();

            // Act
            var result = _service.LimitRecords(countries, recordLimit);

            // Assert
            Assert.Equal(expectedCount, result.Count());
        }

        private IQueryable<CountryDto> GetTestCountries()
        {
            return new List<CountryDto>
            {
                new CountryDto { Name = new CountryName { Common = "India" }, Population = 1000000000 },
                new CountryDto { Name = new CountryName { Common = "USA" }, Population = 331000000 },
                new CountryDto { Name = new CountryName { Common = "Small Country" }, Population = 500000 },
                new CountryDto { Name = new CountryName { Common = "Mid Country" }, Population = 900000 }
            }.AsQueryable();
        }
    }
}
