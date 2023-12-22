using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Logging;
using EuroNewsTest.Model;
using EuroNewsTest.Utils;
using RestSharp;
using System.Text.Json.Nodes;

namespace EuroNewsTest.Api
{
    public class ApiUtils : ApiRequests
    {
        private static ISettingsFile ConfigDataReader => SettingsFilesUtils.GetConfigData();

        private static string Email = ConfigDataReader.GetValue<string>("email");

        public ApiUtils(string accessToken) : base(accessToken)
        {
        }

        public void MarkAllMesaagesRead()
        {
            string endPoint = String.Format(
                EndPointReader.GetValue<string>("post_batch_modify"),
                Email
                );
            string labelToRemove = "UNREAD";
            MessageList messageList = GetAllMessages();

            if (messageList.Messages != null)
            {
                List<string> messagesIds = messageList.Messages
                    .Select(message => message.Id)
                    .ToList();

                BatchModifyMessagesRequest batchModifyMessagesRequest = new BatchModifyMessagesRequest();
                batchModifyMessagesRequest.Ids = messagesIds;
                batchModifyMessagesRequest.RemoveLabelIds = new List<string> { labelToRemove };

                Post(endPoint, batchModifyMessagesRequest);
            }
        }

        public Message GetMessageById(string id)
        {
            string endPoint = String.Format(
                    EndPointReader.GetValue<string>("get_message_by_id"),
                    Email, id
                );
            RestResponse<JsonNode> restResponse = Get(endPoint);

            string body = restResponse.Content.ToString();


            return JsonUtils.DeserializeMessage(body);
        }

        public void MarkMessageAsRead(string id)
        {
            string endPoint = String.Format(
                    EndPointReader.GetValue<string>("post_message_modify"),
                    Email, id
                );

            String labelToRemove = "UNREAD";
            ModifyMessageRequest modifyMessageRequest = new ModifyMessageRequest();
            modifyMessageRequest.RemoveLabelIds = [labelToRemove];
            Post(endPoint, modifyMessageRequest);
        }

        public string ExtractLatestUnreadMessageId()
        {
            MessageList? messageList = GetAllMessages();

            while (messageList.Messages == null)
            {
                messageList = GetAllMessages();
            }

            return messageList.Messages[0].Id;
        }

        public bool IsEuronewsMail()
        {
            var allMessages = GetAllMessages();
            if (allMessages == null)
            {
                var CancellationMessages = GetAllMessages()?.Messages
                    .Where(msg => msg.Payload.Headers
                        .Any(header => header.Name.Equals("Subject", StringComparison.OrdinalIgnoreCase) &&
                            header.Value.Contains("Please verify your email address")
                        )
                    ).ToList();
                return CancellationMessages?.Count == 0;
            }
            else
            {
                return true;
            }
        }

        public bool NoNewMessages()
        {
            var messageList = GetAllMessages();
            if (messageList == null || messageList.Messages == null)
            {
                return true;
            }
            else
            {
                return !messageList.Messages
                    .Select(msg => msg.Payload)
                    .SelectMany(payload => payload.Headers)
                    .Where(header => header.Name.Equals("Subject", StringComparison.OrdinalIgnoreCase))
                    .Any(header => header.Value.Contains("canceling your subscription"));
            }

        }

        public MessageList GetAllMessages()
        {
            string endPoint = String.Format(
                    EndPointReader.GetValue<string>("get_all_messages"),
                    Email
                );

            RestResponse<JsonNode> getResponse = Get(endPoint);

            string body = getResponse.Content.ToString();

            return JsonUtils.DeserializeMessages(body);

        }


    }
}
