using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Logging;
using EuroNewsTest.Model;

namespace EuroNewsTest.Utils
{
    public abstract class GoogleApiHelper
    {
        private static readonly ISettingsFile CreadentialReader = SettingsFilesUtils.GetCredentialData();
        public static Token GetAccessToken()
        {
            string clientId = CreadentialReader.GetValue<string>("client_id");
            string clientSecret = CreadentialReader.GetValue<string>("client_secret");
            string refreshToken = CreadentialReader.GetValue<string>("refresh_token");


            HttpClient client = new HttpClient();
            {
                var formData = new Dictionary<string, string>
            {
                { "client_id", clientId },
                { "client_secret", clientSecret },
                { "refresh_token", refreshToken },
                { "grant_type", "refresh_token" }
            };

                var content = new FormUrlEncodedContent(formData);

                var response = client.PostAsync("https://accounts.google.com/o/oauth2/token", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    Logger.Instance.Info("Token generated");
                    return JsonUtils.DeserializeToken(result);
                }
                else
                {
                    string error = "Error while retrieving token. Status code" + response.StatusCode;
                    Console.WriteLine(error);
                    throw new Exception(error);
                }
            }
        }

    }
}
