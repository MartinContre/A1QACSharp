using System.Text.Json.Serialization;

namespace EuroNewsTest.Model
{
    public class Header
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }

        public override string ToString()
        {
            return $"Header{{Name='{Name}', Value='{Value}'}}";
        }
    }
}
