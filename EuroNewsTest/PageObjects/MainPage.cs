using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace EuroNewsTest.PageObjects
{
    public class MainPage : Form
    {
        private static ILink NewslettersLink => ElementFactory.GetLink(By.XPath("//span[contains(@data-event, 'newsletter-link-header')]"), "Newsletters Link");
        private static ILink LogIn => ElementFactory.GetLink(By.XPath("//span[normalize-space()='Log In']"), "Logg in");

        public MainPage() : base(By.XPath("//a[@aria-label='Euronews Logo']//h1//*[name()='svg']"), "Main Page")
        {
        }

        public bool IsDispleyed() => NewslettersLink.State.WaitForDisplayed();

        public void ClickNewsletterLink()
        {
            NewslettersLink.Click();
        }

        public void ClickLogInLink() 
        {
            LogIn.Click();
        }
    }
}
