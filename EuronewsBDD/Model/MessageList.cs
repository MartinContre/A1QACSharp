using System.Text.Json.Serialization;

namespace EuroNewsTest.Model
{
    public class MessageList
    {
        [JsonPropertyName("messages")]
        public List<Message>? Messages { get; set; }
        
        [JsonPropertyName("nextPageToken")]
        public string? NextPageToken { get; set; }
        
        [JsonPropertyName("resultSizeEstimate")]
        public int ResultSizeEstimate { get; set; }

        public override string ToString()
        {
            return $"MessageList{{Messages={Messages}, NextPageToken='{NextPageToken}', ResultSizeEstimate={ResultSizeEstimate}}}";
        }
    }
}
