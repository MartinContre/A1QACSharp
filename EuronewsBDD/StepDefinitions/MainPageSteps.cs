using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Logging;
using EuroNewsTest.PageObjects;
using EuroNewsTest.Utils;
using NUnit.Framework;

namespace EuronewsBDD.StepDefinitions
{
    [Binding]
    public sealed class MainPageSteps
    {
        private readonly PrivacyPolicy privacyPolicy;
        private readonly MainPage mainPage;
        private readonly NewsletterPage newsletterPage;
        private readonly Browser browser;
        private readonly ISettingsFile configData;
        private string Url;

        public MainPageSteps()
        {
            mainPage = new MainPage();
            privacyPolicy = new PrivacyPolicy();
            newsletterPage = new NewsletterPage();
            browser = AqualityServices.Browser;
            configData = SettingsFilesUtils.GetConfigData();

            Url = configData.GetValue<string>("url");
        }

        [Given(@"the main page of Euronews is opened")]
        public void GivenTheMainPageOfEuronewsIsOpened()
        {
            browser.GoTo(Url);
            browser.Maximize();
            browser.WaitForPageToLoad();
            Logger.Instance.Info("Opened Euronews main page");
        }

        [When(@"I follow the link ""([^""]*)"" in the header")]
        public void WhenIFollowTheLinkInTheHeader(string linkText)
        {
            privacyPolicy.ClickAcceptCookiesBtn();
            mainPage.ClickNewsletterLink();
            Logger.Instance.Info($"Clicked on the '{linkText}' link");
        }


        [Then(@"the page ""([^""]*)"" is opened")]
        public void ThenThePageIsOpened(string pageName)
        {
            Assert.That(newsletterPage.IsDisplayed(), Is.True);
            Logger.Instance.Info($"{pageName} page is opened");
        }


    }
}
