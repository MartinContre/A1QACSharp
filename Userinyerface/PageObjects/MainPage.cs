using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Userinyerface.PageObjects
{
    public class MainPage : Form
    {
        private static ITextBox Logo => ElementFactory.GetTextBox(By.XPath("//p[contains(text(),'Hi and welcome')]"), "Welcome message");
        private static ILink ClickHereLink => ElementFactory.GetLink(By.XPath("//a[@class='start__link']"), "Click here link");
        public MainPage() : base(By.XPath("//div[@class='logo__icon']"), "Main page")
        {
        }

        public bool IsDisplayed()
        {
            return Logo.State.WaitForDisplayed();
        }

        public void ClickLink()
        {
            ClickHereLink.Click();
        }
    }
}
