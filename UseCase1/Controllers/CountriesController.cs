using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using UseCase1.DTO;

namespace UseCase1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public CountriesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries(
            string? countryNameFilter = null,
            int? countryPopulationFilter = null,
            string? sortOrder = "ascend",
            [FromQuery] PaginationDto? pagination = null)
        {
            HttpResponseMessage response;
            try
            {
                response = await _httpClient.GetAsync("https://restcountries.com/v3.1/all");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                return StatusCode(502, $"Error fetching data from external API: {e.Message}");
            }

            List<CountryDto>? countries;
            try
            {
                var json = await response.Content.ReadAsStringAsync();
                countries = JsonSerializer.Deserialize<List<CountryDto>>(json);
            }
            catch (JsonException e)
            {
                return StatusCode(500, $"Error parsing response from external API: {e.Message}");
            }

            if (countries is null)
            {
                return StatusCode(500, "Unexpected error: Parsed data is null.");
            }

            var query = countries.AsQueryable();

            // TODO: Add parameter processing here

            return Ok(query.ToList());
        }
    }
}
