using System.Text.Json.Serialization;

namespace EuroNewsTest.Model
{
    public class BatchModifyMessagesRequest
    {
        [JsonPropertyName("ids")]
        public List<string>? Ids { get; set; }
        
        [JsonPropertyName("addLabelIds")]
        public List<string>? AddLabelIds { get; set; }
        
        [JsonPropertyName("removeLabelIds")]
        public List<string>? RemoveLabelIds { get; set; }


        public override string ToString()
        {
            return $"BatchModifyMessagesRequest{{Ids={Ids}, AddLabelIds={AddLabelIds}, RemoveLabelIds={RemoveLabelIds}}}";
        }

    }
}
