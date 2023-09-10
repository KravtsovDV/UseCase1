using System.Text.Json.Serialization;

namespace UseCase1.DTO
{
    public class CountryDto
    {
        [JsonPropertyName("name")]
        public CountryName? Name { get; set; }

        [JsonPropertyName("population")]
        public int? Population { get; set; }
    }

    public class CountryName
    {
        [JsonPropertyName("common")]
        public string? Common { get; set; }
    }
}
