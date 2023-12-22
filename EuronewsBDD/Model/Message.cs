using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace EuroNewsTest.Model
{
    public class Message
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("threadId")]
        public string? ThreadId { get; set; }

        [JsonPropertyName("labelIds")]
        public List<string>? LabelsIds { get; set; }
        [JsonPropertyName("snippet")]
        public string? Snippet { get; set; }

        [JsonPropertyName("historyId")]
        public string? HistoryId { get; set; }

        [JsonPropertyName("internalDate")]
        public string? InternalDate { get; set; }

        [JsonPropertyName("payload")]
        public MessagePart? Payload { get; set; }

        [JsonPropertyName("sizeEstimate")]
        public int SizeEstimate { get; set; }

        [JsonPropertyName("raw")]
        public string? Raw { get; set; }


        public string? ExtractButtonLink()
        {
            if (Snippet == null)
            {
                return null;
            }

            // Crear un documento HTML a partir del Snippet
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(Snippet);

            // Seleccionar el enlace (a) dentro del documento HTML
            var linkNode = htmlDocument.DocumentNode.SelectSingleNode("//a[@href]");

            // Obtener el valor del atributo href
            string hrefValue = linkNode?.GetAttributeValue("href", "");

            // Devolver el enlace obtenido
            return hrefValue;
        }
        public override string ToString()
        {
            return $"Message{{Id='{Id}', ThreadId='{ThreadId}', LabelsIds={LabelsIds}, Snippet='{Snippet}', HistoryId='{HistoryId}', InternalDate='{InternalDate}', Payload={Payload}, SizeEstimate={SizeEstimate}, Raw='{Raw}'}}";
        }
    }
}
