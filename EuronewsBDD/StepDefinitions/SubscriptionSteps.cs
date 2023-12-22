using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Logging;
using EuroNewsTest.PageObjects;
using EuroNewsTest.Utils;
using NUnit.Framework;
using System.Runtime.Serialization;

namespace EuronewsBDD.StepDefinitions
{
    [Binding]
    public sealed class SubscriptionSteps : BaseSteps
    {
        private readonly ScenarioContext scenarioContext;
        private readonly NewsletterPage newsletterPage;
        private readonly SubscriptionPlanForm subscriptionPlanForm;
        private readonly string Email;


        public SubscriptionSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            newsletterPage = new NewsletterPage();
            subscriptionPlanForm = new SubscriptionPlanForm();

            Email = configData.GetValue<string>("email");
        }


        [When(@"I Choose A Random Newsletter Subscription Plan")]
        public void WhenIChooseARandomNewsletterSubscriptionPlan()
        {
            SubscriptionPlan randomPlan = newsletterPage.SelectRandomSubscriptionPlan();

            scenarioContext["RandomSubscriptionPlan"] = randomPlan;

            Logger.Instance.Info($"Selected random plan: {randomPlan}");
        }

        [When(@"an email form has appeared at the bottom of the page")]
        public void WhenAnEmailFormHasAppearedAtTheBottomOfThePage()
        {
            Assert.That(subscriptionPlanForm.IsDisplayed(), Is.True);
            Logger.Instance.Info("Email form has appeared");
        }

        [When(@"I enter my email and click the ""([^""]*)"" button")]
        public void WhenIEnterMyEmailAndClickTheButton(string submit)
        {
            subscriptionPlanForm.FiilOutEmail(Email);
            subscriptionPlanForm.ClickSubmitSuscriptionBtn();

            Logger.Instance.Info($"Click on {submit} button");

            //browser.Quit();
        }


    }
}
