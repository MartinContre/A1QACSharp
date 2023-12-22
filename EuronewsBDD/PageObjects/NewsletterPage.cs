using Aquality.Selenium.Elements;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using EuroNewsTest.Utils;
using OpenQA.Selenium;

namespace EuroNewsTest.PageObjects
{
    internal class NewsletterPage : Form
    {
        private ITextBox NewsletterSupscriptionPlanContainer => ElementFactory.GetTextBox(By.XPath("//form[@id='newsletters-form']"), "Newsletter subscription plan container");
        private String ChooseNewsletterLocator = ".block.w-full.btn-tertiary.unchecked-label.cursor-pointer";
        private IList<ITextBox> NewslettersAvailableList;

        public NewsletterPage() : base(By.XPath("//span[contains(text(), 'Our newsletters')]"), "Newsletter page")
        {
        }

        public bool IsDisplayed() => NewsletterSupscriptionPlanContainer.State.WaitForDisplayed();

        public SubscriptionPlan SelectRandomSubscriptionPlan()
        {
            NewslettersAvailableList ??= GetAvailableNewsletterBoxes();

            int subscriptionPlansSize = Enum.GetValues(typeof(SubscriptionPlan)).Length;

            int selectedSubscriptionPlanNum = RandomCreator.CreateRandomIndexes(1, subscriptionPlansSize)[0];
            ITextBox chosenSubscriptionPlan = NewslettersAvailableList[selectedSubscriptionPlanNum];

            chosenSubscriptionPlan.FindChildElement<TextBox>(By.CssSelector(ChooseNewsletterLocator)).Click();

            return (SubscriptionPlan)selectedSubscriptionPlanNum;
        }

        public void SelectPreviousSelectedSubscriptionPlan(SubscriptionPlan subscriptionPlan)
        {
            ITextBox choose = NewslettersAvailableList[(int)subscriptionPlan];
            choose.JsActions.ScrollIntoView();

            choose.FindChildElement<ITextBox>(By.CssSelector(ChooseNewsletterLocator)).Click();

            String seePreviewsLocator = ".text-primary.mt-F3.inline-block";
            IButton seePreviewButton = choose.FindChildElement<IButton>(By.CssSelector(seePreviewsLocator));
            seePreviewButton.Click();
        }

        private IList<ITextBox> GetAvailableNewsletterBoxes()
        {
            return NewsletterSupscriptionPlanContainer.FindChildElements<ITextBox>(By.CssSelector(
                ".bg-white.shadow-lg"));
        }
    }
}
