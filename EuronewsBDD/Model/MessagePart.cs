using System.Text.Json.Serialization;

namespace EuroNewsTest.Model
{
    public class MessagePart
    {
        [JsonPropertyName("partId")]
        public string? PartId { get; set; }
        
        [JsonPropertyName("mimeType")]
        public string? MimeType { get; set; }
        
        [JsonPropertyName("filename")]
        public string? FileName { get; set; }
        
        [JsonPropertyName("headers")]
        public List<Header>? Headers { get; set; }
        
        [JsonPropertyName("body")]
        public MessagePartBody? Body { get; set; }

        [JsonPropertyName("parts")]
        public List<MessagePart>? Parts { get; set; }

        public override string ToString()
        {
            return $"MessagePart{{PartId='{PartId}', MimeType='{MimeType}', FileName='{FileName}', Headers={Headers}, Body={Body}, Parts={Parts}}}";
        }
    }
}
