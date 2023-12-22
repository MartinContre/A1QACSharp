using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Logging;
using EuroNewsTest.Api;
using EuroNewsTest.Model;
using EuroNewsTest.Utils;

namespace EuroNewsTest.Tests
{
    public abstract class BaseTest
    {
        protected static Logger Logger => Logger.Instance;
        protected Browser Browser = AqualityServices.Browser;
        protected static ISettingsFile ConfigData => SettingsFilesUtils.GetConfigData();
        protected Token accessToken;
        protected ApiUtils ApiUtils;

        [SetUp]
        public void Setup()
        {
            accessToken = GoogleApiHelper.GetAccessToken();
            ApiUtils = new ApiUtils(accessToken.AccessToken);

            ApiUtils.MarkAllMesaagesRead();
            Logger.Info("Setup startup config"); 
            string url = ConfigData.GetValue<string>("url");

            Browser.Maximize();
            Browser.GoTo(url);
            Browser.WaitForPageToLoad();
        }

        [TearDown]
        public void Teardown()
        {
            Browser.Quit();
        }
    }
}