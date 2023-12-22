using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace EuroNewsTest.PageObjects
{
    internal class SuccessfullySubscriptionConfirmationForm : Form
    {
        private IButton BackToTheSiteBtn => ElementFactory.GetButton(By.XPath("//a[@aria-label='Euronews Logo']//*[name()='svg']"), "Back to the site button");

        public SuccessfullySubscriptionConfirmationForm() : base(By.XPath("//a[@aria-label='Euronews Logo']//*[name()='svg']"),
                "Successfully subscription confirmation")
        {
        }

        public bool IsDisplayed()
        {
            return BackToTheSiteBtn.State.WaitForDisplayed();
        }

        public void ClickBackToSiteBtn()
        {
            BackToTheSiteBtn.Click();
        }
    }
}
