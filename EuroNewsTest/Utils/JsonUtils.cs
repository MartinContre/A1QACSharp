using Aquality.Selenium.Core.Logging;
using EuroNewsTest.Model;
using System.Text.Json;

namespace EuroNewsTest.Utils
{
    public class JsonUtils
    {
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions();

        public static MessageList DeserializeMessages(string responseBody)
        {
            try
            {
                Logger.Instance.Info("Deserializing messages from response.");

#pragma warning disable CS8603 // Possible null reference return.
                return JsonSerializer.Deserialize<MessageList>(responseBody, options);
                #pragma warning restore CS8603 // Possible null reference return.
            }
            catch (JsonException e)
            {
                Logger.Instance.Error("Failed to deserialize response body. " + e.Message);
                throw new Exception(e.Message);
            }
        }

        public static Message DeserializeMessage(string responseBody)
        {
            Logger.Instance.Info("Deserializing message from response.");
#pragma warning disable CS8603 // Possible null reference return.
            return JsonSerializer.Deserialize<Message>(responseBody, options);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public static string SerializeObjectToString(object obj)
        {
            try
            {
                Logger.Instance.Info("Serializing object: " + obj);
                return JsonSerializer.Serialize(obj, options);
            }
            catch (JsonException e)
            {
                Logger.Instance.Error("Failed to serialize object." + e.Message);
                throw new Exception(e.Message);
            }
        }

        public static Token DeserializeToken(string responseBody)
        {
            Logger.Instance.Info("Deserializing message from response.");
#pragma warning disable CS8603 // Possible null reference return.
            return JsonSerializer.Deserialize<Token>(responseBody, options);
#pragma warning restore CS8603 // Possible null reference return.
        }

    }
}
