using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Logging;
using EuroNewsTest.PageObjects;
using EuroNewsTest.Utils;

namespace EuronewsBDD.StepDefinitions
{
    [Binding]
    public sealed class SubscriptionSteps
    {
        private readonly ScenarioContext scenarioContext;
        private readonly NewsletterPage newsletterPage;
        private readonly Browser browser;

        public SubscriptionSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            newsletterPage = new NewsletterPage();
            browser = AqualityServices.Browser;
        }

        [When(@"I Choose A Random Newsletter Subscription Plan")]
        public void WhenIChooseARandomNewsletterSubscriptionPlan()
        {
            SubscriptionPlan randomPlan = newsletterPage.SelectRandomSubscriptionPlan();

            scenarioContext["RandomSubscriptionPlan"] = randomPlan;

            Logger.Instance.Info($"Selected random plan: {randomPlan}");

            browser.Quit();
        }

        [When(@"an email form has appeared at the bottom of the page")]
        public void WhenAnEmailFormHasAppearedAtTheBottomOfThePage()
        {
            throw new PendingStepException();
        }

    }
}
