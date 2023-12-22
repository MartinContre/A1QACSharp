using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace EuroNewsTest.PageObjects
{
    public class PrivacyPolicy : Form
    {
        private IButton AcceptCookiesBtn => ElementFactory.GetButton(By.XPath("//*[@id='didomi-notice-agree-button']"), "Accept Cookies Button");

        public PrivacyPolicy() : base(By.XPath("//span[contains(@class, '-title')]]"), "Privacy policy")
        {
        }

        public bool IsDispleyed() => AcceptCookiesBtn.State.WaitForDisplayed();

        public void ClickAcceptCookiesBtn()
        {
            AcceptCookiesBtn.Click();
        }
    }
}
