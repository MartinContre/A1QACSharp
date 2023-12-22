using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Logging;
using EuroNewsTest.Model;
using EuroNewsTest.Utils;
using RestSharp;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace EuroNewsTest.Api
{
    public abstract class ApiRequests
    {

        protected static readonly ISettingsFile EndPointReader = SettingsFilesUtils.GetEndPointData();
        private static readonly string BaseUri = EndPointReader.GetValue<string>("base_URI");

        private static string? AccessToken;

        public ApiRequests(string accessToken)
        {
            AccessToken = accessToken;
        }

        public static RestResponse<JsonNode> Get(string endPoint)
        {
            string url = BaseUri + endPoint;
            try
            {
                Logger.Instance.Info("Retrieving HTTP response from: " + url);
                var client = new RestClient(url);
                var request = new RestRequest();
                request.Method = Method.Get;
                request.AddHeader("Authorization", "Bearer " + AccessToken);
                request.AddHeader("Content-Type", "application/json");
                var response = client.Execute<JsonNode>(request);
                return response;
            }
            catch (Exception e)
            {
                string errorMessage = "Failed to retrieve HTTP response from: " + url + ". Error message: " + e.Message;
                Logger.Instance.Error(errorMessage);
                throw new Exception(errorMessage, e);
            }
        }

            public static void Post(string endPoint, object obj)
            {
                string requestBody = JsonSerializer.Serialize(obj);
                string requestUrl = BaseUri + endPoint;
                try
                {
                    Logger.Instance.Info("Sending POST request to: " + requestUrl);
                    var client = new RestClient(requestUrl);
                    var request = new RestRequest();
                    request.Method = Method.Post;
                    request.AddHeader("Authorization", "Bearer " + AccessToken);
                    request.AddHeader("Content-Type", "application/json");
                    request.AddJsonBody(requestBody);
                    client.Execute(request);
                }
                catch (Exception e)
                {
                    string errorMessage = String.Format("Failed to retrieve HTTP POST response from: {0}. Error message: {1}", requestUrl, e.Message);
                    Logger.Instance.Error(errorMessage);
                    throw new Exception(errorMessage, e);
                }
            }
        }


    }

