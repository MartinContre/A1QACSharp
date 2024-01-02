using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Userinyerface.PageObjects
{
    public class CookiesForm : Form
    {
        private static IButton AcceptCookiesBtn => ElementFactory.GetButton(By.XPath("//button[normalize-space()='Not really, no']"), "Accept Cookies button");
        private static ILabel CookiesMessage => ElementFactory.GetLabel(By.XPath("//p[@class='cookies__message']"), "Cookies message");
        public CookiesForm() : base(By.XPath("//p[@class='cookies__message']"), "Cookies form")
        {
        }

        public bool MessageDipalyed()
        {
            return CookiesMessage.State.WaitForNotDisplayed();
        }

        public void ClickAcceptCookies()
        {
            AcceptCookiesBtn.State.WaitForClickable();
            AcceptCookiesBtn.Click();
        }
    }
}
