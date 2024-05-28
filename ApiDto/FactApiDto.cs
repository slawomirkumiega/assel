using System.Text.Json.Serialization;

namespace Assel.ApiDto
{
    public class FactApiDto
    {
        public required string _Id { get; set; }
        public required string User { get; set; }
        public required string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetType Type { get; set; }

    }
}
