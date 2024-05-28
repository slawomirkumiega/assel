using System.Text.Json.Serialization;

namespace Assel.ApiDto
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PetType
    {
        Cat = 1
    }
}
