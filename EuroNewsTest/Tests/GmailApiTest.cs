using Aquality.Selenium.Core.Logging;
using EuroNewsTest.Api;
using EuroNewsTest.Model;
using EuroNewsTest.PageObjects;
using EuroNewsTest.Utils;

namespace EuroNewsTest.Tests
{
    public class GmailApiTest : BaseTest
    {

        private readonly string Email = ConfigData.GetValue<string>("email");
        private readonly string Password = ConfigData.GetValue<string>("password");

        [Test]
        public void EurnonewsTest()
        {
            PrivacyPolicy privacyPolicy = new PrivacyPolicy();
            MainPage mainPage = new MainPage();
            NewsletterPage newsletter = new NewsletterPage();
            SubscriptionPlanForm subscriptionPlanForm = new SubscriptionPlanForm();
            SuccessfullySubscriptionConfirmationForm successfullySubscriptionConfirmationForm = new SuccessfullySubscriptionConfirmationForm();
            SubscriptionPreviewForm subscriptionPreviewForm = new SubscriptionPreviewForm();
            NewsletterUnsubscriptionForm newsletterUnsubscriptionForm = new NewsletterUnsubscriptionForm();
            CompleteSubscription completeSubscription = new CompleteSubscription();
            MyAccount myAccount = new MyAccount();
            SettingsForm settingsForm = new SettingsForm();
            UnsuscribeForm unsuscribeForm = new UnsuscribeForm();


            Assert.That(privacyPolicy.IsDispleyed(), Is.True, "Privacy Policy has not been displayed!");

            privacyPolicy.ClickAcceptCookiesBtn();

            Logger.Info("Main page of Euronews is opened");
            Assert.That(mainPage.IsDispleyed(), Is.True, "Main page has not been open!");
            mainPage.ClickNewsletterLink();

            Logger.Info("Page Newsletters is opened");
            Assert.That(newsletter.IsDisplayed(), Is.True, "Newsletter Menu has not been open!");
            SubscriptionPlan selected = newsletter.SelectRandomSubscriptionPlan();

            Logger.Info($"Selected subscription plan: {selected}");
            Assert.That(subscriptionPlanForm.IsDisplayed(), Is.True, "Subscription Plan Email Form has not been displayed!");
            subscriptionPlanForm.FiilOutEmail(Email);
            subscriptionPlanForm.ClickSubmitSuscriptionBtn();

            Assert.That(completeSubscription.IsDisplayed(), Is.True, "Complete your registration to receive our newsletters not displayed!");
            completeSubscription.FillPassword(Password);
            completeSubscription.ClickCreateAccountBtn();

            Assert.That(ApiUtils.IsEuronewsMail(), Is.True, "There is no message received to confirm subscription in Euronews platform!");
            string lastMessageId = ApiUtils.ExtractLatestUnreadMessageId();
            Logger.Instance.Info($"Last message id: {lastMessageId}");
            Message lastMessage = ApiUtils.GetMessageById(lastMessageId);
            string uri = StringUtils.ExtractRedirectUri(lastMessage);
            Logger.Instance.Info($"Link: {uri}");

            Browser.GoTo(uri);
            Assert.That(successfullySubscriptionConfirmationForm.IsDisplayed(), Is.True, "Succesfully subscription not open");
            successfullySubscriptionConfirmationForm.ClickBackToSiteBtn();

            Assert.That(mainPage.IsDispleyed(), Is.True, "Main page has not been displayed!");
            mainPage.ClickLogInLink();

            Assert.That(myAccount.IsDisplayed(), Is.True, "My account page not displayed");
            myAccount.ClickSettingsBtn();

            Assert.That(settingsForm.IsDispleyed(), Is.True, "Setting form not displayed");
            settingsForm.ClickDeleteAccount();

            Assert.That(unsuscribeForm.IsDispleyed(), Is.True, "Unsuscribe succesfully message not displayed");

        }
    }
}
