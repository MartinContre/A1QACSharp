using System.Text.Json.Serialization;

namespace EuroNewsTest.Model
{
    public class MessagePartBody
    {
        [JsonPropertyName("attachmentId")]
        public string? AttachmentId { get; set; }
        
        [JsonPropertyName("size")]
        public int? Size { get; set; }
        
        [JsonPropertyName("data")]
        public string? Data { get; set; }

        public override string ToString()
        {
            return $"MessagePartBody{{AttachmentId='{AttachmentId}', Size={Size}, Data='{Data}'}}";
        }
    }
}
