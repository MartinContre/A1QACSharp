using System.Text.Json.Serialization;

namespace EuroNewsTest.Model
{
    public class ModifyMessageRequest
    {
        [JsonPropertyName("addLabelIds")]
        public List<string>? AddLabelIds { get; set; }
        [JsonPropertyName("removeLabelIds")]
        public List<string>? RemoveLabelIds { get; set; }
    }
}
