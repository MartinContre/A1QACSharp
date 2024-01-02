using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Logging;
using Aquality.Selenium.Core.Utilities;
using Userinyerface.PageObjects;
using Userinyerface.Utilis;

namespace Userinyerface.Test
{
    public class BaseTest
    {
        protected Browser browser;
        protected MainPage mainPage;
        protected static ISettingsFile ConfigData => SettingFileUtils.GetConfigData();
        protected static ISettingsFile TestData => SettingFileUtils.GetTestData();

        [SetUp]
        public void Setup()
        {
            Logger.Instance.Info("Setup startup config");

            string url = ConfigData.GetValue<string>("url");

            browser = AqualityServices.Browser;
            browser.GoTo(url);
            browser.Maximize();
            browser.WaitForPageToLoad();

            mainPage = new MainPage();
            Assert.That(mainPage.IsDisplayed(), Is.True);
            mainPage.ClickLink();
        }

        [TearDown]
        public void TearDown()
        {
            browser.Quit();
        }
    }
}
